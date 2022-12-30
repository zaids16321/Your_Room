using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Your_Room.Models;

namespace Your_Room.Controllers
{
    public class ApartmentsadsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApartmentsadsController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Apartmentsads
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Apartmentsads.Include(a => a.AddressNavigation).Include(a => a.DurationNavigation).Include(a => a.UserinfoNavigation);
            return View(await modelContext.ToListAsync());
        }
        public async Task<IActionResult> AllApartment()
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var modelContext = _context.Apartmentsads.Where(i=> i.Userinfo== HttpContext.Session.GetInt32("Customer_Id")).Include(a => a.AddressNavigation).Include(a => a.DurationNavigation).Include(a => a.UserinfoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Apartmentsads/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");


            if (id == null)
            {
                return NotFound();
            }

            var apartmentsad = await _context.Apartmentsads
                .Include(a => a.AddressNavigation)
                .Include(a => a.DurationNavigation)
                .Include(a => a.UserinfoNavigation)
                .FirstOrDefaultAsync(m => m.Adid == id);
            if (apartmentsad == null)
            {
                return NotFound();
            }

            return View(apartmentsad);
        }

        // GET: Apartmentsads/Create
        public IActionResult Create()
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "City");
            ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Rentalduration");
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid");
            return View();
        }

        // POST: Apartmentsads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Apartmentsad apartmentsad)
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");

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

                if (apartmentsad.ImageFile2 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile2.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        apartmentsad.ImageFile2.CopyTo(fileStream);
                    }
                    apartmentsad.Image2 = fileName;
                }


                if (apartmentsad.ImageFile3 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile3.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        apartmentsad.ImageFile3.CopyTo(fileStream);
                    }
                    apartmentsad.Image3 = fileName;
                }


                if (apartmentsad.ImageFile4 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile4.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        apartmentsad.ImageFile4.CopyTo(fileStream);
                    }
                    apartmentsad.Image4 = fileName;
                }

                if (apartmentsad.ImageFile5 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile5.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        apartmentsad.ImageFile5.CopyTo(fileStream);
                    }
                    apartmentsad.Image5 = fileName;
                }

                if (apartmentsad.ImageFile6 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile6.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        apartmentsad.ImageFile6.CopyTo(fileStream);
                    }
                    apartmentsad.Image6 = fileName;
                }


                if (apartmentsad.ImageFile7 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile7.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        apartmentsad.ImageFile7.CopyTo(fileStream);
                    }
                    apartmentsad.Image7 = fileName;
                }

                if (apartmentsad.ImageFile8 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile8.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        apartmentsad.ImageFile8.CopyTo(fileStream);
                    }
                    apartmentsad.Image8 = fileName;
                }

                apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                apartmentsad.Addate = DateTime.Now;
                _context.Add(apartmentsad);
                await _context.SaveChangesAsync();
                return RedirectToAction();
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "City", apartmentsad.Address);
            ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Rentalduration", apartmentsad.Duration);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", apartmentsad.Userinfo);
            return View(apartmentsad);
        }

        // GET: Apartmentsads/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var apartmentsad = await _context.Apartmentsads.FindAsync(id);
            if (apartmentsad == null)
            {
                return NotFound();
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "City", apartmentsad.Address);
            ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Rentalduration", apartmentsad.Duration);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", apartmentsad.Userinfo);
            return View(apartmentsad);
        }

        // POST: Apartmentsads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id,  Apartmentsad apartmentsad)
        {
            if (id != apartmentsad.Adid)
            {
                return NotFound();
            }
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            if (ModelState.IsValid)
            {
                try
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
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                        apartmentsad.Userinfo= HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate= DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }

                    if (apartmentsad.ImageFile2 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile2.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            apartmentsad.ImageFile2.CopyTo(fileStream);

                        }
                        apartmentsad.Image2 = fileName;
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                        apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate = DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }

                    if (apartmentsad.ImageFile3 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile3.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            apartmentsad.ImageFile3.CopyTo(fileStream);

                        }
                        apartmentsad.Image3 = fileName;
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                        apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate = DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }

                    if (apartmentsad.ImageFile4 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile4.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            apartmentsad.ImageFile4.CopyTo(fileStream);

                        }
                        apartmentsad.Image4 = fileName;
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                        apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate = DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }

                    if (apartmentsad.ImageFile5 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile5.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            apartmentsad.ImageFile5.CopyTo(fileStream);

                        }
                        apartmentsad.Image5 = fileName;
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                        apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate = DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }

                    if (apartmentsad.ImageFile6 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile6.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            apartmentsad.ImageFile6.CopyTo(fileStream);

                        }
                        apartmentsad.Image6 = fileName;
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                        apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate = DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }

                    if (apartmentsad.ImageFile7 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile7.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            apartmentsad.ImageFile7.CopyTo(fileStream);

                        }
                        apartmentsad.Image7 = fileName;
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                        apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate = DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }

                    if (apartmentsad.ImageFile8 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + apartmentsad.ImageFile8.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            apartmentsad.ImageFile8.CopyTo(fileStream);

                        }
                        apartmentsad.Image8 = fileName;
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        apartmentsad.Addate = DateTime.Now;
                        _context.Update(apartmentsad);
                        await _context.SaveChangesAsync();
                    }
                    //else
                    //{
                    //    //apartmentsad.Image8 = HttpContext.Session.GetString("Customer_Image");
                    //    apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                    //    apartmentsad.Addate = DateTime.Now;
                    //    _context.Update(apartmentsad);
                    //    await _context.SaveChangesAsync();
                    //}
                    if (apartmentsad.ImageFile1 == null && apartmentsad.ImageFile2 == null && apartmentsad.ImageFile3 == null &&
                        apartmentsad.ImageFile4 == null && apartmentsad.ImageFile5 == null && apartmentsad.ImageFile6 == null &&
                        apartmentsad.ImageFile7 == null && apartmentsad.ImageFile8 == null )
                    {
                        apartmentsad.Image1 = _context.Apartmentsads.Where(i=>i.Adid== apartmentsad.Adid).Select(u => u.Image1).FirstOrDefault();
                        apartmentsad.Image2 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image2).FirstOrDefault();
                        apartmentsad.Image3 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image3).FirstOrDefault();
                        apartmentsad.Image4 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image4).FirstOrDefault();
                        apartmentsad.Image5 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image5).FirstOrDefault();
                        apartmentsad.Image6 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image6).FirstOrDefault();
                        apartmentsad.Image7 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image7).FirstOrDefault();
                        apartmentsad.Image8 = _context.Apartmentsads.Where(i => i.Adid == apartmentsad.Adid).Select(u => u.Image8).FirstOrDefault();
                    }
                    apartmentsad.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                    apartmentsad.Addate = DateTime.Now;
                    _context.Update(apartmentsad);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("AllAds", "Ads");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentsadExists(apartmentsad.Adid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
             
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "City", apartmentsad.Address);
            ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Rentalduration", apartmentsad.Duration);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", apartmentsad.Userinfo);
            return View(apartmentsad);
        }

        // GET: Apartmentsads/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var apartmentsad = await _context.Apartmentsads
                .Include(a => a.AddressNavigation)
                .Include(a => a.DurationNavigation)
                .Include(a => a.UserinfoNavigation)
                .FirstOrDefaultAsync(m => m.Adid == id);
            if (apartmentsad == null)
            {
                return NotFound();
            }

            return View();
        }

        //// POST: Apartmentsads/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var apartmentsad = await _context.Apartmentsads.FindAsync(id);
            _context.Apartmentsads.Remove(apartmentsad);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllAds", "Ads");
        }

        private bool ApartmentsadExists(decimal id)
        {
            return _context.Apartmentsads.Any(e => e.Adid == id);
        }
    }
}
