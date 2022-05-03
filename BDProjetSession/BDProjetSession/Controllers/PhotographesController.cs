using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDProjetSession.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BDProjetSession.Controllers
{
    public class PhotographesController : Controller
    {
        private readonly H22_4D5_Projet_sessionContext _context;
        private IConfiguration _configuration;
        private SqlConnection connectionVotreBDSQL;

        public PhotographesController(H22_4D5_Projet_sessionContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(DateTime dateDebut,DateTime dateFin,int photographeId)
        {
            ViewData["Photographes"] = new SelectList(_context.Photographes, "Id", "Nom", photographeId);
            connectionVotreBDSQL = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connectionVotreBDSQL.Open();

            SqlCommand commandSQL = connectionVotreBDSQL.CreateCommand();
            commandSQL.CommandText = "EXEC Disponibilites.uspListRDV @dateDebut = '"+ dateDebut + "', @dateFin = '"+ dateFin+"',@id = " + photographeId;
            SqlDataReader resultat = commandSQL.ExecuteReader();

            //demande de l'aide
           /* List<RendezVou> rendezVous = new List<RendezVou>();
            while (resultat.Read())
            {
                Propriete propriete = new Propriete();
                foreach(var item in _context.Proprietes)
                {
                    if (item.ProprieteId == int.Parse(resultat["photographeID"].ToString()))
                    {
                        propriete = item;
                    }
                    
                }
                RendezVou rendezVou = new RendezVou();
                foreach (var item in _context.RendezVous)
                {
                    if (item.RendezVousId == int.Parse(resultat["rendexVousID"].ToString()))
                    {
                        rendezVou = item;
                    }
                }
            }

            rendezVous.Add(new  )
        }*/
        // GET: Photographes
        public async Task<IActionResult> Index()
        {
            ViewData["Photographes"] = new SelectList(_context.Photographes, "Id", "Nom");

            return View(await _context.Photographes.ToListAsync());
        }

        // GET: Photographes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographe = await _context.Photographes
                .FirstOrDefaultAsync(m => m.PhotographeId == id);
            if (photographe == null)
            {
                return NotFound();
            }

            return View(photographe);
        }

        // GET: Photographes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photographes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotographeId,Nom")] Photographe photographe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photographe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photographe);
        }

        // GET: Photographes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographe = await _context.Photographes.FindAsync(id);
            if (photographe == null)
            {
                return NotFound();
            }
            return View(photographe);
        }

        // POST: Photographes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotographeId,Nom")] Photographe photographe)
        {
            if (id != photographe.PhotographeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photographe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotographeExists(photographe.PhotographeId))
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
            return View(photographe);
        }

        // GET: Photographes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographe = await _context.Photographes
                .FirstOrDefaultAsync(m => m.PhotographeId == id);
            if (photographe == null)
            {
                return NotFound();
            }

            return View(photographe);
        }

        // POST: Photographes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photographe = await _context.Photographes.FindAsync(id);
            _context.Photographes.Remove(photographe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotographeExists(int id)
        {
            return _context.Photographes.Any(e => e.PhotographeId == id);
        }
    }
}
