using BTRS.Models;
using FootballGame.Date;
using Microsoft.AspNetCore.Mvc;

namespace BTRS.Controllers
{
    public class PassengerController : Controller
    {
        private SystemDbContext _context;

        public PassengerController(SystemDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Passenger passenger)
        {
            bool empty = CheckEmpty(passenger);
            bool duplicate = CheckUsername(passenger.username);

            if (empty)
            {
                if (duplicate)
                {
                    _context.passenger.Add(passenger);
                    _context.SaveChanges();

                    TempData["Msg"] = "The data was saved";
                    return View();
                }
                else
                {
                    TempData["Msg"] = "Please change the username";
                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Please fill in all input fields";
                return View();
            }
        }

        public bool CheckUsername(string username)
        {
            Passenger existingPassenger = _context.passenger
                .Where(p => p.username.Equals(username))
                .FirstOrDefault();

            return existingPassenger == null;
        }

        public bool CheckEmpty(Passenger passenger)
        {
            return !string.IsNullOrEmpty(passenger.username)
                && !string.IsNullOrEmpty(passenger.password)
                && !string.IsNullOrEmpty(passenger.Name)
                && !string.IsNullOrEmpty(passenger.Email)
                && !string.IsNullOrEmpty(passenger.phonenumber);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login passengerlogin)
        {
            if (ModelState.IsValid)
            {
                string username = passengerlogin.username;
                string password = passengerlogin.password;

                Passenger passenger = _context.passenger.Where(
                     u => u.username.Equals(username) &&
                     u.password.Equals(password)
                     ).FirstOrDefault();

                Admin admin = _context.admin.Where(
                    a => a.username.Equals(username)
                    &&
                    a.password.Equals(password)
                    ).FirstOrDefault();




                if (passenger != null)
                {
                    HttpContext.Session.SetInt32("userID", passenger.PassengerID);

                    return RedirectToAction("AvailableTripList");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.AdminID);

                    return RedirectToAction("Index", "Teams");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }


            }
            else
            {

            }
            return View();
           
        }


        [HttpGet]
        public IActionResult AvailableTripList()
        {
            return View(_context.trip.ToList());
        }

       

    }
}
