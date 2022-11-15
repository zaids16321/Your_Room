using System;
using System.Collections.Generic;

#nullable disable

namespace Your_Room.Models
{
    public partial class Address
    {
        public Address()
        {
            Apartmentsads = new HashSet<Apartmentsad>();
            Furnitures = new HashSet<Furniture>();
        }

        public decimal Addresid { get; set; }
        public string City { get; set; }

        public virtual ICollection<Apartmentsad> Apartmentsads { get; set; }
        public virtual ICollection<Furniture> Furnitures { get; set; }
    }
}
