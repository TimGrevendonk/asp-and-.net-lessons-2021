using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;
using System;
using System.Linq;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
        // Make _context available in a var to use in every method.
        private readonly GPContext _context;

        // The constructor.
        public ShopController(GPContext context)
        {
            _context = context;
        }

        public IActionResult OrderTicket()
        {
            ViewData["bannernr"] = 3;
            ViewData["Title"] = "Order Tickets";
            ViewData["Countries"] =
               // SelectList = Country sorted on name.
               new SelectList(_context.Countries.OrderBy(c => c.Name),
               // With the ID of the country.
               "CountryID",
               // And with the name of the country.
               "Name");

            ViewData["Races"] = _context.Races.OrderBy(r => r.Name).ToList();

            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // All the values that CAN be send in the form
        // To avoid people trying to enter different data into the database (i.e. admin = true).
        public IActionResult Create([Bind("Name, Email, Address, CountryID, RaceID, Number")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.OrderDate = DateTime.Now;
                ticket.Paid = false;

                _context.Add(ticket);
                _context.SaveChanges();
                // Redirect ot a page with an ID.
                return RedirectToAction("ConfirmOrder", new{id=ticket.TicketID });
            }
            return View(ticket);
        }


        public IActionResult ConfirmOrder(int id)
        {
            ViewData["bannernr"] = 3;
            ViewData["Title"] = "Confirmation";
            // Make a join with the race table (for the name and date of the race).
            var ticket = _context.Tickets.Include(t => t.Race)
                .SingleOrDefault(i => i.TicketID == id);

            return View(ticket);
        }

        public IActionResult ListTickets(int raceID = 0)
        {
            ViewData["bannernr"] = 3;
            ViewData["Title"] = "Ordered tickets";
            var listTicketsVM = new ListTicketsViewModel();
            listTicketsVM.Races = new SelectList(_context.Races.OrderBy(race => race.Name), "RaceID", "Name");
            if (raceID != 0)
            {
                listTicketsVM.Tickets = _context.Tickets.Where(ticket => ticket.RaceID == raceID)
                    .OrderBy(ticket => ticket.OrderDate)
                    .Include(country => country.Country)
                    .ToList();
            } else {
                listTicketsVM.Tickets = _context.Tickets
                    .OrderBy(ticket => ticket.OrderDate)
                    .Include(country => country.Country)
                    .ToList();
            }
            // Set the new raceID in case of filter submit.
            listTicketsVM.raceID = raceID;

            return View(listTicketsVM);
        }

        // GET: Shop/Edit
        public IActionResult EditTicket(int id)
        {
            ViewData["bannernr"] = 3;
            ViewData["Title"] = "Edit ticket";

            var ticketHolder = _context.Tickets
                .Include(country => country.Country)
                .Include(race => race.Race)
                .SingleOrDefault(ticket => ticket.TicketID == id);

            return View(ticketHolder);
        }

        // POST: Shop/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket(int id, [Bind("TicketID,Paid")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Attach the Current ticket to change the data for.
                    _context.Attach(ticket);
                    // Say what to modified in the Ticket.
                    // Save the fields that are changed on the current ticket.
                    _context.Entry(ticket).Property(t => t.Paid).IsModified = true;
                    // Save to database.
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("ListTickets");
            }
            return View(ticket);
        }
    }
}
