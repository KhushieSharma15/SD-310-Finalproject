using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTunes.Data;
using MyTunes.Models;

namespace MyTunes.Controllers
{
    public class UsersPlaylistsController : Controller
    {
        private readonly MyTunesContext _context;

        public UsersPlaylistsController(MyTunesContext context)
        {
            _context = context;
        }

        // GET: UsersPlaylists
        public async Task<IActionResult> Index()
        {
            var myTunesContext = _context.UsersPlaylists.Include(u => u.Song).Include(u => u.User);
            return View(await myTunesContext.ToListAsync());
        }

        // GET: UsersPlaylists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsersPlaylists == null)
            {
                return NotFound();
            }

            var usersPlaylist = await _context.UsersPlaylists
                .Include(u => u.Song)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersPlaylist == null)
            {
                return NotFound();
            }

            return View(usersPlaylist);
        }

        // GET: UsersPlaylists/Create
        public IActionResult Create()
        {
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: UsersPlaylists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,SongId")] UsersPlaylist usersPlaylist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersPlaylist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", usersPlaylist.SongId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usersPlaylist.UserId);
            return View(usersPlaylist);
        }

        // GET: UsersPlaylists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsersPlaylists == null)
            {
                return NotFound();
            }

            var usersPlaylist = await _context.UsersPlaylists.FindAsync(id);
            if (usersPlaylist == null)
            {
                return NotFound();
            }
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", usersPlaylist.SongId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usersPlaylist.UserId);
            return View(usersPlaylist);
        }

        // POST: UsersPlaylists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,SongId")] UsersPlaylist usersPlaylist)
        {
            if (id != usersPlaylist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersPlaylist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersPlaylistExists(usersPlaylist.Id))
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
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", usersPlaylist.SongId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usersPlaylist.UserId);
            return View(usersPlaylist);
        }

        // GET: UsersPlaylists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsersPlaylists == null)
            {
                return NotFound();
            }

            var usersPlaylist = await _context.UsersPlaylists
                .Include(u => u.Song)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersPlaylist == null)
            {
                return NotFound();
            }

            return View(usersPlaylist);
        }

        // POST: UsersPlaylists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsersPlaylists == null)
            {
                return Problem("Entity set 'MyTunesContext.UsersPlaylists'  is null.");
            }
            var usersPlaylist = await _context.UsersPlaylists.FindAsync(id);
            if (usersPlaylist != null)
            {
                _context.UsersPlaylists.Remove(usersPlaylist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersPlaylistExists(int id)
        {
          return (_context.UsersPlaylists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
