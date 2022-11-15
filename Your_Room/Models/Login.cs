using System;
using System.Collections.Generic;

#nullable disable

namespace Your_Room.Models
{
    public partial class Login
    {
        public decimal Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? Userid { get; set; }

        public virtual User User { get; set; }
    }
}
