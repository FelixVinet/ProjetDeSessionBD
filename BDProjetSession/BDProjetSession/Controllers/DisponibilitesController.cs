using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDProjetSession.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace BDProjetSession.Controllers
{
    public class DisponibilitesController : Controller
    {
        private readonly H22_4D5_Projet_sessionContext _context;
        private IConfiguration _configuration;
        private SqlConnection connectionVotreBDSQL;

        public DisponibilitesController(H22_4D5_Projet_sessionContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public IActionResult OnGet(DateTime dateDebut, DateTime dateFin, int photographeId)
        {
            ViewData["Photographes"] = new SelectList(_context.RendezVous, "PhotographeID", "Nom", photographeId);
            connectionVotreBDSQL = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connectionVotreBDSQL.Open();

            SqlCommand commandSQL = connectionVotreBDSQL.CreateCommand();
            commandSQL.CommandText = "EXEC Disponibilites.uspListRDV @dateDebut = '" + dateDebut + "', @dateFin = '" + dateFin + "',@id = " + photographeId;
            SqlDataReader resultat = commandSQL.ExecuteReader();

            //demande de l'aide
            List<Disponibilite> ListDispo = new List<Disponibilite>();
            while (resultat.Read())
            {
                Disponibilite disponibilite = _context.Disponibilites.Find(int.Parse(resultat["DisponibiliteId"].ToString()));
                
                    ListDispo.Add(new Disponibilite(
                    int.Parse(resultat["DisponibiliteId"].ToString()),
                    DateTime.Parse(resultat["DateDisponibilite"].ToString()),
                    int.Parse(resultat["PhotographeId"].ToString()),
                    TimeSpan.Parse(resultat["HeureDebut"].ToString()),
                    int.Parse(resultat["RendezVousId"].ToString()),
                    resultat["Statut"].ToString(),
                    TimeSpan.Parse(resultat["HeureFin"].ToString())
                    ));


            };
            resultat.Close();

            ViewData["dateDebut"] = dateDebut.ToString("s");
            ViewData["dateFin"] = dateFin.ToString("s");
            ViewData["id"] = photographeId;

            if (ListDispo.Count != 0)
            {
                return View("Index", ListDispo);
            }
            else
            {
                return View("Index");
            }
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
                disponibilite.RendezVousId = null;
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
