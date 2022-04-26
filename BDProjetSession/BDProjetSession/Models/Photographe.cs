using System;
using System.Collections.Generic;

#nullable disable

namespace BDProjetSession.Models
{
    public partial class Photographe
    {
        public Photographe()
        {
            Disponibilites = new HashSet<Disponibilite>();
        }

        public int PhotographeId { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Disponibilite> Disponibilites { get; set; }
    }
}
