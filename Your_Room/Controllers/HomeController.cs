using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Your_Room.Models;

namespace Your_Room.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger , ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var apartmentsads = _context.Apartmentsads.Include(a => a.AddressNavigation).Include(a => a.DurationNavigation).Include(a => a.UserinfoNavigation);
            var furnitures = _context.Furnitures.Include(f => f.AddressNavigation).Include(f => f.UserinfoNavigation);
            var model = Tuple.Create<IEnumerable<Apartmentsad>, IEnumerable<Furniture>>(apartmentsads, furnitures);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
