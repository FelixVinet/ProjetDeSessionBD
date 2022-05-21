using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDProjetSession.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BDProjetSession.Controllers
{
    public class PhotosController : Controller
    {
        private readonly H22_4D5_Projet_sessionContext _context;

        public PhotosController(H22_4D5_Projet_sessionContext context)
        {
            _context = context;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            var h22_4D5_Projet_sessionContext = _context.Photos.Include(p => p.RendezVous);
            return View(await h22_4D5_Projet_sessionContext.ToListAsync());
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .Include(p => p.RendezVous)
                .FirstOrDefaultAsync(m => m.PhotoId == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoId,Nom,RendezVousId")] Photo photo, List<IFormFile> postedFiles)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(postedFiles[0].FileName);
                fileName = photo.RendezVousId + "_" + fileName;
                using(FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), ".\\wwwroot\\images\\" + fileName), FileMode.Create))
                {
                    postedFiles[0].CopyTo(stream);
                }
                string ext = fileName.Split(".")[1].ToLower();
                if(ext == "jpg"|| ext == "jpeg"|| ext == "png")
                {
                    photo.Nom = fileName;
                    _context.Add(photo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return View();
                }
            }
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId", photo.RendezVousId);
            return View(photo);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId", photo.RendezVousId);
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoId,Nom,RendezVousId")] Photo photo)
        {
            if (id != photo.PhotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.PhotoId))
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
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId", photo.RendezVousId);
            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .Include(p => p.RendezVous)
                .FirstOrDefaultAsync(m => m.PhotoId == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(int id)
        {
            return _context.Photos.Any(e => e.PhotoId == id);
        }
    }
}
