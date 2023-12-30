using BTRS.Models;
using BTRS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTRS.Controllers
{


    public class TripsController : Controller
    {
        private SystemDbContext _context;
        public TripsController(SystemDbContext context)
        {
            this._context = context;
        }
        // GET: TripsController
        public ActionResult Index()
        {
            return View(_context.trip.ToList());
        }

        // GET: TripsController/Details/5
        public ActionResult Details(int id)
        {
            Trip trip = _context.trip.Find(id);
            return View(trip);
        }

        // GET: TripsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trip trips)
        {
            try
            {
                int adminid = (int)HttpContext.Session.GetInt32("AdminID");

                Admin admin = _context.admin.Where(
                  a => a.AdminID == adminid
                  ).FirstOrDefault();

                trips.Admin = admin;

                _context.trip.Add(trips);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripsController/Edit/5
        public ActionResult Edit(int id)
        {
            Trip trips= _context.trip.Find(id);
            return View(trips);
        }

        // POST: TripsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trip trips)
        {
            try
            {
                _context.trip.Update(trips);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripsController/Delete/5
        public ActionResult Delete(int id)
        {
            Trip trips = _context.trip.Find(id);
            _context.trip.Remove(trips);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        // POST: TripsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Trip trips)
        {
            try
            {
                _context.trip.Remove(trips);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
