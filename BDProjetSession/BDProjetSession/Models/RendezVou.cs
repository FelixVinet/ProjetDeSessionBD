using System;
using System.Collections.Generic;

#nullable disable

namespace BDProjetSession.Models
{
    public partial class RendezVou
    {
        public RendezVou()
        {
            Disponibilites = new HashSet<Disponibilite>();
            Photos = new HashSet<Photo>();
        }

        public int RendezVousId { get; set; }
        public DateTime DateRendezVous { get; set; }
        public string Commentaire { get; set; }
        public int ProprieteId { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public string Justification { get; set; }
        public string StatutPhoto { get; set; }
        public string CommentairePhotos { get; set; }
        public TimeSpan? HeureFin { get; set; }

        public virtual Propriete Propriete { get; set; }
        public virtual ICollection<Disponibilite> Disponibilites { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
