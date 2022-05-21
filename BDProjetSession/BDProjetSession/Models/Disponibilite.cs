using System;
using System.Collections.Generic;

#nullable disable

namespace BDProjetSession.Models
{
    public partial class Disponibilite
    {
        public Disponibilite(int DisponibiliteId, DateTime DateDisponibilite, int PhotographeId, TimeSpan HeureDebut, int? RendezVousId, string Statut, TimeSpan? HeureFin)
        {
            this.DisponibiliteId = DisponibiliteId;
            this.DateDisponibilite = DateDisponibilite;
            this.PhotographeId = PhotographeId;
            this.HeureDebut = HeureDebut;
            this.RendezVousId = RendezVousId;
            this.Statut = Statut;
            this.HeureFin = HeureFin;
        }
        public int DisponibiliteId { get; set; }
        public DateTime DateDisponibilite { get; set; }
        public int PhotographeId { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public int? RendezVousId { get; set; }
        public string Statut { get; set; }
        public TimeSpan? HeureFin { get; set; }

        public virtual Photographe Photographe { get; set; }
        public virtual RendezVou RendezVous { get; set; }
    }
}
