using System;
using System.Collections.Generic;

#nullable disable

namespace BDProjetSession.Models
{
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public string Nom { get; set; }
        public int RendezVousId { get; set; }

        public virtual RendezVou RendezVous { get; set; }
    }
}
