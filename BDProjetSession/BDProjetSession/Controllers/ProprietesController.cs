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
    public class ProprietesController : Controller
    {
        private readonly H22_4D5_Projet_sessionContext _context;

        public ProprietesController(H22_4D5_Projet_sessionContext context)
        {
            _context = context;
        }

        // GET: Proprietes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proprietes.ToListAsync());
        }

        // GET: Proprietes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propriete = await _context.Proprietes
                .FirstOrDefaultAsync(m => m.ProprieteId == id);
            if (propriete == null)
            {
                return NotFound();
            }

            return View(propriete);
        }

        // GET: Proprietes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proprietes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProprieteId,Adresse,Ville,NomProprio,TelProprio")] Propriete propriete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propriete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propriete);
        }

        // GET: Proprietes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propriete = await _context.Proprietes.FindAsync(id);
            if (propriete == null)
            {
                return NotFound();
            }
            return View(propriete);
        }

        // POST: Proprietes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProprieteId,Adresse,Ville,NomProprio,TelProprio")] Propriete propriete)
        {
            if (id != propriete.ProprieteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propriete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprieteExists(propriete.ProprieteId))
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
            return View(propriete);
        }

        // GET: Proprietes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propriete = await _context.Proprietes
                .FirstOrDefaultAsync(m => m.ProprieteId == id);
            if (propriete == null)
            {
                return NotFound();
            }

            return View(propriete);
        }

        // POST: Proprietes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propriete = await _context.Proprietes.FindAsync(id);
            _context.Proprietes.Remove(propriete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprieteExists(int id)
        {
            return _context.Proprietes.Any(e => e.ProprieteId == id);
        }
    }
}
