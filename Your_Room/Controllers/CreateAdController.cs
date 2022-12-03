using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Your_Room.Models
{
    public class CreateAdController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateAdController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }
   
    [HttpGet]
    public IActionResult Create()
    {
        ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid");
        ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Id");
        ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid");
        return View();
    }

    // POST: Apartmentsads/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Adid,Adtitel,Addate,Descriptions,Price,Numofperson,Numofroom,Numofbed,Address,Street,BuildingNumber,Electricitybillprice,Waterbillprice,Duration,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Userinfo,ImageFile1")] Apartmentsad apartmentsad)
    {


        if (ModelState.IsValid)
        {
            if (apartmentsad.ImageFile1 != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile1.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    apartmentsad.ImageFile1.CopyTo(fileStream);
                }
                apartmentsad.Image1 = fileName;
            }

            _context.Add(apartmentsad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid", apartmentsad.Address);
        ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Id", apartmentsad.Duration);
        ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", apartmentsad.Userinfo);
        return View(apartmentsad);
    }


}

}