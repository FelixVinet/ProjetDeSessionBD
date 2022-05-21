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
    public class RendezVousController : Controller
    {
        private readonly H22_4D5_Projet_sessionContext _context;
        private IConfiguration _configuration;
        private SqlConnection connectionVotreBDSQL;

        public RendezVousController(H22_4D5_Projet_sessionContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public IActionResult OnGet(DateTime dateDebut, DateTime dateFin, int photographeId)
        {
            ViewData["Photographes"] = new SelectList(_context.Photographes, "PhotographeID", "Nom", photographeId);
            connectionVotreBDSQL = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connectionVotreBDSQL.Open();

            SqlCommand commandSQL = connectionVotreBDSQL.CreateCommand();
            commandSQL.CommandText = "EXEC Disponibilites.uspListRDV @dateDebut = '" + dateDebut + "', @dateFin = '" + dateFin + "',@id = " + photographeId;
            SqlDataReader resultat = commandSQL.ExecuteReader();

            //demande de l'aide
            List<RendezVou> rendezVousList = new List<RendezVou>();
            while (resultat.Read())
            {
                RendezVou rendezVou = _context.RendezVous.Find(int.Parse(resultat["RendezVousID"].ToString()));
                // public RendezVou(int id, DateTime dateRendezvous, string commentaire, int proprieteId, TimeSpan heureDebut, string justification, string statutPhoto, string commentairePhotos, TimeSpan heurefin)
                rendezVousList.Add(new RendezVou(
                    int.Parse(resultat["RendezVousID"].ToString()),
                    DateTime.Parse(resultat["dateRendezvous"].ToString()),
                    resultat["commentaire"].ToString(),
                    int.Parse(resultat["proprieteID"].ToString()),
                    TimeSpan.Parse(resultat["heureDebut"].ToString()),
                    resultat["justification"].ToString(),
                    resultat["statutPhoto"].ToString(),
                    resultat["commentairePhotos"].ToString(),
                    TimeSpan.Parse(resultat["HeureFin"].ToString())
                    ));


            };
            resultat.Close();

            ViewData["dateDebut"] = dateDebut.ToString("s");
            ViewData["dateFin"] = dateFin.ToString("s");
            ViewData["id"] = photographeId;

            if (rendezVousList.Count != 0)
            {
                return View("Index", rendezVousList);
            }
            else
            {
                return View("Index");
            }
        }

        // GET: RendezVous
        public async Task<IActionResult> Index()
        {
            var h22_4D5_Projet_sessionContext = _context.RendezVous.Include(r => r.Propriete);
            ViewData["Photographes"] = new SelectList(_context.Photographes, "PhotographeId", "Nom");
            return View(await h22_4D5_Projet_sessionContext.ToListAsync());
        }

        // GET: RendezVous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVou = await _context.RendezVous
                .Include(r => r.Propriete)
                .FirstOrDefaultAsync(m => m.RendezVousId == id);
            if (rendezVou == null)
            {
                return NotFound();
            }

            return View(rendezVou);
        }

        // GET: RendezVous/Create
        public IActionResult Create()
        {
            ViewData["ProprieteId"] = new SelectList(_context.Proprietes, "ProprieteId", "Adresse");
            return View();
        }

        // POST: RendezVous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RendezVousId,DateRendezVous,Commentaire,ProprieteId,HeureDebut,Justification,StatutPhoto,CommentairePhotos,HeureFin")] RendezVou rendezVou)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(rendezVou);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProprieteId"] = new SelectList(_context.Proprietes, "ProprieteId", "Adresse", rendezVou.proprieteID);
            return View(rendezVou);
        }

        // GET: RendezVous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVou = await _context.RendezVous.FindAsync(id);
            if (rendezVou == null)
            {
                return NotFound();
            }
            ViewData["ProprieteId"] = new SelectList(_context.Proprietes, "ProprieteId", "Adresse", rendezVou.proprieteID);
            return View(rendezVou);
        }

        // POST: RendezVous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RendezVousId,DateRendezVous,Commentaire,ProprieteId,HeureDebut,Justification,StatutPhoto,CommentairePhotos,HeureFin")] RendezVou rendezVou)
        {
            if (id != rendezVou.RendezVousId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rendezVou);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendezVouExists(rendezVou.RendezVousId))
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
            ViewData["ProprieteId"] = new SelectList(_context.Proprietes, "ProprieteId", "Adresse", rendezVou.proprieteID);
            return View(rendezVou);
        }

        // GET: RendezVous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVou = await _context.RendezVous
                .Include(r => r.Propriete)
                .FirstOrDefaultAsync(m => m.RendezVousId == id);
            if (rendezVou == null)
            {
                return NotFound();
            }

            return View(rendezVou);
        }

        // POST: RendezVous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rendezVou = await _context.RendezVous.FindAsync(id);
            _context.RendezVous.Remove(rendezVou);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendezVouExists(int id)
        {
            return _context.RendezVous.Any(e => e.RendezVousId == id);
        }
    }
}
