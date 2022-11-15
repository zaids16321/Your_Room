using System;
using System.Collections.Generic;

#nullable disable

namespace Your_Room.Models
{
    public partial class Duration
    {
        public Duration()
        {
            Apartmentsads = new HashSet<Apartmentsad>();
        }

        public decimal Id { get; set; }
        public string Rentalduration { get; set; }

        public virtual ICollection<Apartmentsad> Apartmentsads { get; set; }
    }
}
