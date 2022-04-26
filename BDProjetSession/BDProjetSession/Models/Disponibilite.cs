using System;
using System.Collections.Generic;

#nullable disable

namespace BDProjetSession.Models
{
    public partial class Disponibilite
    {
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
