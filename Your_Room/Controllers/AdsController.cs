using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var apartmentsads = _context.Apartmentsads.Include(a => a.AddressNavigation).Include(a => a.DurationNavigation).Include(a => a.UserinfoNavigation);
            var furnitures = _context.Furnitures.Include(f => f.AddressNavigation).Include(f => f.UserinfoNavigation);
            var address = _context.Addresses;
            var dur = _context.Durations;


            var Ads = Tuple.Create<IEnumerable<Apartmentsad>, IEnumerable<Furniture>, IEnumerable<Address>, IEnumerable<Duration>>(apartmentsads, furnitures, address, dur);


            return View(Ads);
        }
        public IActionResult AllAds()
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var apartmentsads = _context.Apartmentsads.Where(i => i.Userinfo == HttpContext.Session.GetInt32("Customer_Id")).Include(a => a.AddressNavigation).Include(a => a.DurationNavigation).Include(a => a.UserinfoNavigation);
            var furnitures = _context.Furnitures.Where(i => i.Userinfo == HttpContext.Session.GetInt32("Customer_Id")).Include(f => f.AddressNavigation).Include(f => f.UserinfoNavigation);
            var address = _context.Addresses;
            var dur = _context.Durations;


            var Ads = Tuple.Create<IEnumerable<Apartmentsad>, IEnumerable<Furniture>, IEnumerable<Address>, IEnumerable<Duration>>(apartmentsads, furnitures, address, dur);


            return View(Ads);

        }
    }
}
