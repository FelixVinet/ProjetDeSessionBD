using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDProjetSession.Models;

namespace BDProjetSession.Controllers
{
    public class DisponibilitesController : Controller
    {
        private readonly H22_4D5_Projet_sessionContext _context;

        public DisponibilitesController(H22_4D5_Projet_sessionContext context)
        {
            _context = context;
        }

        // GET: Disponibilites
        public async Task<IActionResult> Index()
        {
            var h22_4D5_Projet_sessionContext = _context.Disponibilites.Include(d => d.Photographe).Include(d => d.RendezVous);
            return View(await h22_4D5_Projet_sessionContext.ToListAsync());
        }

        // GET: Disponibilites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilite = await _context.Disponibilites
                .Include(d => d.Photographe)
                .Include(d => d.RendezVous)
                .FirstOrDefaultAsync(m => m.DisponibiliteId == id);
            if (disponibilite == null)
            {
                return NotFound();
            }

            return View(disponibilite);
        }

        // GET: Disponibilites/Create
        public IActionResult Create()
        {
            ViewData["PhotographeId"] = new SelectList(_context.Photographes, "PhotographeId", "Nom");
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId");
            return View();
        }

        // POST: Disponibilites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisponibiliteId,DateDisponibilite,PhotographeId,HeureDebut,RendezVousId,Statut,HeureFin")] Disponibilite disponibilite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disponibilite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotographeId"] = new SelectList(_context.Photographes, "PhotographeId", "Nom", disponibilite.PhotographeId);
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId", disponibilite.RendezVousId);
            return View(disponibilite);
        }

        // GET: Disponibilites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilite = await _context.Disponibilites.FindAsync(id);
            if (disponibilite == null)
            {
                return NotFound();
            }
            ViewData["PhotographeId"] = new SelectList(_context.Photographes, "PhotographeId", "Nom", disponibilite.PhotographeId);
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId", disponibilite.RendezVousId);
            return View(disponibilite);
        }

        // POST: Disponibilites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisponibiliteId,DateDisponibilite,PhotographeId,HeureDebut,RendezVousId,Statut,HeureFin")] Disponibilite disponibilite)
        {
            if (id != disponibilite.DisponibiliteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisponibiliteExists(disponibilite.DisponibiliteId))
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
            ViewData["PhotographeId"] = new SelectList(_context.Photographes, "PhotographeId", "Nom", disponibilite.PhotographeId);
            ViewData["RendezVousId"] = new SelectList(_context.RendezVous, "RendezVousId", "RendezVousId", disponibilite.RendezVousId);
            return View(disponibilite);
        }

        // GET: Disponibilites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilite = await _context.Disponibilites
                .Include(d => d.Photographe)
                .Include(d => d.RendezVous)
                .FirstOrDefaultAsync(m => m.DisponibiliteId == id);
            if (disponibilite == null)
            {
                return NotFound();
            }

            return View(disponibilite);
        }

        // POST: Disponibilites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disponibilite = await _context.Disponibilites.FindAsync(id);
            _context.Disponibilites.Remove(disponibilite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisponibiliteExists(int id)
        {
            return _context.Disponibilites.Any(e => e.DisponibiliteId == id);
        }
    }
}
