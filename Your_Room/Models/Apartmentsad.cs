using System;
using System.Collections.Generic;

#nullable disable

namespace Your_Room.Models
{
    public partial class Apartmentsad
    {
        public decimal Adid { get; set; }
        public string Adtitel { get; set; }
        public DateTime? Addate { get; set; }
        public string Descriptions { get; set; }
        public decimal? Price { get; set; }
        public decimal? Numofperson { get; set; }
        public decimal? Numofroom { get; set; }
        public decimal? Numofbed { get; set; }
        public decimal? Address { get; set; }
        public string Street { get; set; }
        public decimal? BuildingNumber { get; set; }
        public decimal? Electricitybillprice { get; set; }
        public decimal? Waterbillprice { get; set; }
        public decimal? Duration { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string Image6 { get; set; }
        public string Image7 { get; set; }
        public string Image8 { get; set; }
        public decimal? Userinfo { get; set; }

        public virtual Address AddressNavigation { get; set; }
        public virtual Duration DurationNavigation { get; set; }
        public virtual User UserinfoNavigation { get; set; }
    }
}
