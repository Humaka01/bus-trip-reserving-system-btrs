using BTRS.Models;
using BTRS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                    // Retrieve the newly generated PassengerID
                    int passengerID = passenger.PassengerID;

                    // Set the PassengerID in the session
                    HttpContext.Session.SetInt32("PassengerID", passengerID);

                    // Redirect to the available trips page
                    return RedirectToAction("AvailableTripList");
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
                    HttpContext.Session.SetInt32("PassengerID", passenger.PassengerID);

                    return RedirectToAction("AvailableTripList");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("AdminID", admin.AdminID);

                    return RedirectToAction("Index", "Trips");
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

        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the Index action
            return RedirectToAction("Login");
        }






        [HttpGet]
        public IActionResult AvailableTripList()
        {
            int? userID = (int)HttpContext.Session.GetInt32("PassengerID");
           List<int> lst = _context.passenger_trips.Where(
                t=>t.passenger.PassengerID ==userID).Select(s=>s.trip.TripID).ToList();


          List <Trip> lst_trip = _context.trip.Where(
                t=>lst.Contains(t.TripID)==false).ToList();
            return View(lst_trip);
        }

        public IActionResult BookTrip(int id)
        {
            int tripID = id;
            int userID = (int)HttpContext.Session.GetInt32("PassengerID");

            Passenger_Trips passengerTrip = new Passenger_Trips();
            passengerTrip.passenger = _context.passenger.Find(userID);
            passengerTrip.trip = _context.trip.Find(tripID);

            _context.passenger_trips.Add(passengerTrip);
            _context.SaveChanges();

            return RedirectToAction("SelectSeats", new { tripID });
        }

        public IActionResult MyBookings()
        {
            // Ensure that the passenger is authenticated and PassengerID is stored in the session
            int loggedInPassengerID = (int)HttpContext.Session.GetInt32("PassengerID");

            // Retrieve the booked trip IDs for the logged-in passenger
            List<int> bookedTripIds = _context.passenger_trips
                .Where(pt => pt.passenger.PassengerID == loggedInPassengerID)
                .Select(pt => pt.trip.TripID)
                .ToList();

            // Retrieve the booked trips for the logged-in passenger
            List<Trip> bookedTrips = _context.trip
                .Where(t => bookedTripIds.Contains(t.TripID))
                .ToList();

            return View(bookedTrips);
        }


        public IActionResult CancelBooking(int id)
        {




            int userID = (int)HttpContext.Session.GetInt32("PassengerID");

            Passenger_Trips bookingToDelete = _context.passenger_trips
                .FirstOrDefault(b => b.passenger.PassengerID == userID && b.trip.TripID == id);

            if (bookingToDelete != null)
            {
                _context.passenger_trips.Remove(bookingToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("MyBookings");
        }



        public IActionResult ViewBusDetails(int id)
        {
            // Retrieve the trip details along with available buses
            var trip = _context.trip
                .Include(t => t.Buses)
                .FirstOrDefault(t => t.TripID == id);

            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }



        // PassengerController.cs

        public IActionResult SelectSeats(int tripId)
        {
            // Retrieve the trip details along with available seats
            var trip = _context.trip
                .Include(t => t.Buses)
                .FirstOrDefault(t => t.TripID == tripId);

            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }


        // PassengerController.cs

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmBooking(int tripId, int selectedSeats)
        {
            int passengerId = (int)HttpContext.Session.GetInt32("PassengerID");

            // Find the trip
            var trip = _context.trip
                .Include(t => t.Buses) // Assuming Trip has a navigation property Buses
                .FirstOrDefault(t => t.TripID == tripId);

            if (trip != null)
            {
                // Calculate the total available seats across all buses for the selected trip
                int totalAvailableSeats = trip.Buses.Sum(b => b.NumOfSeats);

                // Check if the selected seats are available
                if (selectedSeats > 0 && selectedSeats <= totalAvailableSeats)
                {
                    // Update the selected seats for the trip
                    trip.SelectedSeats = selectedSeats;

                    // Update the available seats for each bus
                    foreach (var bus in trip.Buses)
                    {
                        int availableSeatsForBus = Math.Min(bus.NumOfSeats, selectedSeats);
                        bus.NumOfSeats -= availableSeatsForBus;
                        selectedSeats -= availableSeatsForBus;
                    }

                    // Save changes to the database
                    _context.SaveChanges();

                    return RedirectToAction("MyBookings");
                }

                // Handle the case where selected seats are not available
                ModelState.AddModelError(string.Empty, "Selected seats are not available.");
            }

            // Handle the case where the trip is not found
            return NotFound();
        }

















    }
}
