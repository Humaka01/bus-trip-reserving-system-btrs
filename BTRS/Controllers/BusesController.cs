using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTRS.Data;
using BTRS.Models;

namespace BTRS.Controllers
{
    public class BusesController : Controller
    {
        private readonly SystemDbContext _context;

        public BusesController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: Buses
        public async Task<IActionResult> Index()
        {
              return _context.bus != null ? 
                          View(await _context.bus.ToListAsync()) :
                          Problem("Entity set 'SystemDbContext.bus'  is null.");
        }

        // GET: Buses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus
                .FirstOrDefaultAsync(m => m.BusID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // GET: Buses/Create
        public IActionResult Create()
        {
            var trips = _context.trip.ToList();
            ViewBag.Trips = trips;
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form)
        {
            int tripID = int.Parse(form["TripID"]); // Assuming you have a field for tripID in your form
            string captainName = form["CaptainName"].ToString();
            int numberOfSeats = int.Parse(form["NumOfSeats"]);

            Bus bus = new Bus();
            bus.CaptainName = captainName;
            bus.NumOfSeats = numberOfSeats;

            bus.trip = _context.trip.Find(tripID); // Assuming you have a navigation property named Trip

            _context.bus.Add(bus);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: Buses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var trips = _context.trip.ToList();
            ViewBag.Trips = trips;
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id ,IFormCollection form)
        {
            int tripID = int.Parse(form["TripID"]); // Assuming you have a field for tripID in your form
            string captainName = form["CaptainName"].ToString();
            int numberOfSeats = int.Parse(form["NumOfSeats"]);
            id = int.Parse(form["BusID"]);
            Bus bus =  _context.bus.Find(tripID);
            bus.CaptainName = captainName;
            bus.NumOfSeats = numberOfSeats;

            bus.trip = _context.trip.Find(tripID); // Assuming you have a navigation property named Trip

            _context.bus.Update(bus);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Buses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus
                .FirstOrDefaultAsync(m => m.BusID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bus == null)
            {
                return Problem("Entity set 'SystemDbContext.bus'  is null.");
            }
            var bus = await _context.bus.FindAsync(id);
            if (bus != null)
            {
                _context.bus.Remove(bus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(int id)
        {
          return (_context.bus?.Any(e => e.BusID == id)).GetValueOrDefault();
        }
    }
}
