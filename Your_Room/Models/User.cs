using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Your_Room.Models
{
    public partial class User
    {
        public User()
        {
            Apartmentsads = new HashSet<Apartmentsad>();
            Furnitures = new HashSet<Furniture>();
            Logins = new HashSet<Login>();
        }

        public decimal Userid { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? Phonenumber { get; set; }
        public string UserImage { get; set; }
        public string Gender { get; set; }
        public decimal? Age { get; set; }
        public string Usertype { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }
        public virtual ICollection<Apartmentsad> Apartmentsads { get; set; }
        public virtual ICollection<Furniture> Furnitures { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
