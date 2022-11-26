using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Your_Room.Models;

namespace Your_Room.Controllers
{
    public class AdsController : Controller
    {
        private readonly ModelContext _context;

        public AdsController(ModelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var apartmentsads = _context.Apartmentsads.Include(a => a.AddressNavigation).Include(a => a.DurationNavigation).Include(a => a.UserinfoNavigation);
            var furnitures = _context.Furnitures.Include(f => f.AddressNavigation).Include(f => f.UserinfoNavigation);
            var Ads = Tuple.Create<IEnumerable<Apartmentsad>, IEnumerable<Furniture>>(apartmentsads, furnitures);


            return View(Ads);
        }

    }
}
