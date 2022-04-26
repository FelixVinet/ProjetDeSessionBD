using System;
using System.Collections.Generic;

#nullable disable

namespace BDProjetSession.Models
{
    public partial class Propriete
    {
        public Propriete()
        {
            RendezVous = new HashSet<RendezVou>();
        }

        public int ProprieteId { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string NomProprio { get; set; }
        public string TelProprio { get; set; }

        public virtual ICollection<RendezVou> RendezVous { get; set; }
    }
}
