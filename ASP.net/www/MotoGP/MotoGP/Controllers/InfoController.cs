using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        public readonly GPContext _context;
        public IActionResult ListRaces()
        {
            ViewData["bannernr"] = 0;
            ViewData["Title"] = "Races";
            var races = _context.Races
                .OrderBy(r => r.Date);

            return View(races.ToList());
        }

        public InfoController(GPContext context)
        {
            _context = context;
        }

        public IActionResult ShowRace(int id)
        {
            ViewData["bannernr"] = 0;
            var race = _context.Races
                .SingleOrDefault(r => r.RaceID == id);

            return View(race);
        }

        public IActionResult ListRiders()
        {
            ViewData["bannernr"] = 1;
            // Get table content of "Rider" connected to the table "Country"
            var Riders = _context.Riders
                // .Include(country => country.Country)
                .OrderBy(rider => rider.Number);

            return View(Riders.ToList());
        }

        public IActionResult BuildMap()
        {
            var races = _context.Races;
            ViewData["bannernr"] = 0;
            ViewData["Title"] = "Races on map";

            return View(races.ToList());
        }

        public IActionResult SelectRace(int raceID = 0)
        {
            ViewData["bannernr"] = 0;
            ViewData["Title"] = "Races";
                // Create a new object in listRacesViewModel to add data to.
            var listRacesVM = new ListRacesViewModel();
                // Put the races in a selectList...
            listRacesVM.Races = new SelectList(_context.Races.OrderBy(m => m.Name),
                    // And put the names of the races corresponding to the IDs in it.
                "RaceID", "Name");
            // If an ID is given fill in the race (with details).
            if (raceID != 0)
            {
                listRacesVM.Race = _context.Races.SingleOrDefault(r => r.RaceID == raceID);
            }
            listRacesVM.raceID = raceID;

            return View(listRacesVM);
        }
        public IActionResult ListTeams()
        {
            ViewData["bannernr"] = 2;
            ViewData["Title"] = "Teams";
                // Use the ViewModel. 
            var listTeamsVM = new ListTeamsViewModel();
                // Fill the Teams attribute in the ViewModel.
            listTeamsVM.Teams = _context.Teams
                .OrderBy(team => team.Name)
                .Include(team => team.Riders)
                .ToList();
                // Return the object from the ViewModel.
            return View(listTeamsVM);
        }

        public IActionResult ListTeamsRiders(int id = 0)
        {
            ViewData["bannernr"] = 2;
            ViewData["Title"] = "Teams & Riders";
                // Use the viewModel.
            var listTeamsRidersVM = new ListTeamsRidersViewModel();
                // Fill the ViewModel attributes.
            listTeamsRidersVM.Teams = _context.Teams
                .OrderBy(team => team.Name)
                .ToList();
                // Check if an ID has been returned (from filtering).
            if (id != 0)
            {
                    // Add the rider(s) to the ViewModel attributes.
                listTeamsRidersVM.Riders = _context.Riders
                    .Where(t => t.TeamID == id)
                    .OrderBy(r => r.FirstName)
                    .ToList();
            }
                // Add the teamID to the ViewModel attirbute (for in view if statement).
            listTeamsRidersVM.teamID = id;
                // Return the object from the ViewModel.
            return View(listTeamsRidersVM);
        }
    }
}
