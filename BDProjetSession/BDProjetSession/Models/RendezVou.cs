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
        public RendezVou(int RendezVousID, DateTime dateRendezvous, string commentaire, int proprieteID, TimeSpan heureDebut, string justification, string statutPhoto, string commentairePhotos,TimeSpan HeureFin)
        {
            this.RendezVousId = RendezVousID;
            this.dateRendezvous = dateRendezvous;
            this.commentaire = commentaire;
            this.proprieteID = proprieteID;
            this.heureDebut = heureDebut;
            this.justification = justification;
           this.statutPhoto = statutPhoto;
           this. commentairePhotos = commentairePhotos;
           this.HeureFin = HeureFin;
        }


        public int RendezVousId { get; set; }
        public DateTime dateRendezvous { get; set; }
        public string commentaire { get; set; }
        public int proprieteID { get; set; }
        public TimeSpan heureDebut { get; set; }
        public string justification { get; set; }
        public string statutPhoto { get; set; }
        public string commentairePhotos { get; set; }
        public TimeSpan? HeureFin { get; set; }

        public virtual Propriete Propriete { get; set; }
        public virtual ICollection<Disponibilite> Disponibilites { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
