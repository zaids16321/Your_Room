using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Your_Room.Models
{
    public partial class Furniture
    {
        public decimal Fid { get; set; }
        public string Ftitel { get; set; }
        public DateTime? Fdate { get; set; }
        public string Descriptions { get; set; }
        public decimal? Price { get; set; }
        public decimal? Address { get; set; }
        public string Street { get; set; }
        public decimal? BuildingNumber { get; set; }
        public string Image1 { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile1 { get; set; }
        public string Image2 { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile2 { get; set; }

        public string Image3 { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile3 { get; set; }
        public string Image4 { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile4 { get; set; }
        public string Image5 { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile5 { get; set; }
        public string Image6 { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile6 { get; set; }
        public string Image7 { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile7 { get; set; }
        public string Image8 { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile8 { get; set; }
        public decimal? Userinfo { get; set; }

        public virtual Address AddressNavigation { get; set; }
        public virtual User UserinfoNavigation { get; set; }
    }
}
