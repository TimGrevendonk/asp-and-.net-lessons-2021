using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Models.ViewModels;

namespace MusicStore.Controllers
{
    // State that the Controller belongs to the admin area. (Area must be mapped in startup.cs, under Configure -> UseEndpoints)
    [Area("Admin")]
    // Is set in ConfigureServices of Startup.cs to use roles.
    [Authorize(Roles = "Administrator")]
    public class AlbumsController : Controller
    {
        private readonly StoreContext _context;

        // Inject the Context to use as database, if SaveChanges() is used in methods the context will update the real database.
        public AlbumsController(StoreContext context)
        {
            _context = context;
        }

        // GET: Albums
        // PArameters come from selection dropdown in "Albums -> index" and can be null/undefined so must have default values.
        public async Task<IActionResult> Index(int artistID = 0, int genreID = 0, string title = null)
        {
            // Makes use of the ViewModel to pass multiple different types of items.
            var listAlbumsVM = new ListAlbumsViewModel();

     
            listAlbumsVM.Artists = new SelectList(_context.Artists
                // Artists are sorted on name (the object themselves)
                .OrderBy(a => a.Name)
                // with the ID of the artist (What am i interested in)
                , "ArtistID"
                // And with the name of the artist (what will the user see)
                , "Name");

            listAlbumsVM.Genres = new SelectList(_context.Genres
                .OrderBy(a => a.Name)
                , "GenreID"
                , "Name");

            // Initialize the basic query needed, add where clauses later on conditions.
            listAlbumsVM.Albums = _context.Albums
                    // Include == Eager loading.
                    .Include(a => a.Artist)
                    .Include(a => a.Genre)
                    .ToList();

            // add more where clouses to the variable of the to query item.
            if (genreID != 0)
            {
                listAlbumsVM.Albums = listAlbumsVM.Albums
                    .Where(a => a.GenreID == genreID).ToList();
            }
            if (artistID != 0)
            {
                listAlbumsVM.Albums = listAlbumsVM.Albums
                    .Where(a => a.ArtistID == artistID).ToList();
            }
            // String values have null as default value, so check on null.
            if (title != null)
            {
                listAlbumsVM.Albums = listAlbumsVM.Albums
                    .Where(a => a.Title.Contains(title)).ToList();
            }

            // Returns to "Albums > Index" in the Admin area.
            return View(listAlbumsVM);
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // The name you give in asp-route-... must correspond to the method attribute.
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                // Include == Eager loading.
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name");
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumID,GenreID,ArtistID,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name", album.GenreID);
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name", album.GenreID);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumID,GenreID,ArtistID,Title,Price,AlbumArtUrl")] Album album)
        {
            if (id != album.AlbumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name", album.GenreID);
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // The name you give in asp-route-... must correspond to the method attribute.
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                // Include == Eager loading.
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        // Delete must have the actionName "Delete" specified.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumID == id);
        }
    }
}
