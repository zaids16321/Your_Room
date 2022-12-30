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
    public class FurnituresController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FurnituresController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Furnitures
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Furnitures.Include(f => f.AddressNavigation).Include(f => f.UserinfoNavigation);
            return View(await modelContext.ToListAsync());
        }
       // GET: Apartmentsads/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var furnitures = await _context.Furnitures
                .Include(a => a.AddressNavigation)
                //.Include(a => a.DurationNavigation)
                .Include(a => a.UserinfoNavigation)
                .FirstOrDefaultAsync(m => m.Fid == id);
            if (furnitures == null)
            {
                return NotFound();
            }

            return View(furnitures);
        }
        // GET: Furnitures/Details/5
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

        // POST: furnitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Furniture furniture)
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");

            if (ModelState.IsValid)
            {
                if (furniture.ImageFile1 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile1.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile1.CopyTo(fileStream);
                    }
                    furniture.Image1 = fileName;
                }

                if (furniture.ImageFile2 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile2.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile2.CopyTo(fileStream);
                    }
                    furniture.Image2 = fileName;
                }


                if (furniture.ImageFile3 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile3.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile3.CopyTo(fileStream);
                    }
                    furniture.Image3 = fileName;
                }


                if (furniture.ImageFile4 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile4.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile4.CopyTo(fileStream);
                    }
                    furniture.Image4 = fileName;
                }

                if (furniture.ImageFile5 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile5.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile5.CopyTo(fileStream);
                    }
                    furniture.Image5 = fileName;
                }

                if (furniture.ImageFile6 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile6.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile6.CopyTo(fileStream);
                    }
                    furniture.Image6 = fileName;
                }


                if (furniture.ImageFile7 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile7.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile7.CopyTo(fileStream);
                    }
                    furniture.Image7 = fileName;
                }

                if (furniture.Image8 != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                    string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile8.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        furniture.ImageFile8.CopyTo(fileStream);
                    }
                    furniture.Image8 = fileName;
                }

                furniture.Userinfo= HttpContext.Session.GetInt32("Customer_Id");
                furniture.Fdate = DateTime.Now;
                _context.Add(furniture);
                await _context.SaveChangesAsync();
                return RedirectToAction();
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "City", furniture.Address);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", furniture.Userinfo);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid");
            return View(furniture);
        }

        // GET: Furnitures/Edit/5
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
            var furniture = await _context.Furnitures.FindAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "City", furniture.Address);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", furniture.Userinfo);
            return View(furniture);
        }

        // POST: Furnitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Fid,Ftitel,Fdate,Descriptions,Price,Address,Street,BuildingNumber,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Userinfo")] Furniture furniture)
        {
            if (id != furniture.Fid)
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
                    if (furniture.ImageFile1 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile1.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile1.CopyTo(fileStream);

                        }
                        furniture.Image1 = fileName;
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }

                    if (furniture.ImageFile2 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile2.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile2.CopyTo(fileStream);

                        }
                        furniture.Image2 = fileName;
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }

                    if (furniture.ImageFile3 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile3.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile3.CopyTo(fileStream);

                        }
                        furniture.Image3 = fileName;
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }

                    if (furniture.ImageFile4 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile4.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile4.CopyTo(fileStream);

                        }
                        furniture.Image4 = fileName;
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }

                    if (furniture.ImageFile5 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile5.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile5.CopyTo(fileStream);

                        }
                        furniture.Image5 = fileName;
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }

                    if (furniture.ImageFile6 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile6.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile6.CopyTo(fileStream);

                        }
                        furniture.Image6 = fileName;
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }

                    if (furniture.ImageFile7 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile7.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile7.CopyTo(fileStream);

                        }
                        furniture.Image7 = fileName;
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }

                    if (furniture.ImageFile8 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + furniture.ImageFile8.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            furniture.ImageFile8.CopyTo(fileStream);

                        }
                        furniture.Image8 = fileName;
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                        furniture.Fdate = DateTime.Now;
                        _context.Update(furniture);
                        await _context.SaveChangesAsync();
                    }
                    //else
                    //{
                    //    //apartmentsad.Image8 = HttpContext.Session.GetString("Customer_Image");
                    //    furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                    //    furniture.Fdate = DateTime.Now;
                    //    _context.Update(furniture);
                    //    await _context.SaveChangesAsync();
                    //}
                    if (furniture.ImageFile1 == null && furniture.ImageFile2 == null && furniture.ImageFile3 == null &&
                        furniture.ImageFile4 == null && furniture.ImageFile5 == null && furniture.ImageFile6 == null &&
                        furniture.ImageFile7 == null && furniture.ImageFile8 == null)
                    {
                        furniture.Image1 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image1).FirstOrDefault();
                        furniture.Image2 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image2).FirstOrDefault();
                        furniture.Image3 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image3).FirstOrDefault();
                        furniture.Image4 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image4).FirstOrDefault();
                        furniture.Image5 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image5).FirstOrDefault();
                        furniture.Image6 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image6).FirstOrDefault();
                        furniture.Image7 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image7).FirstOrDefault();
                        furniture.Image8 = _context.Furnitures.Where(i => i.Fid == furniture.Fid).Select(u => u.Image8).FirstOrDefault();
                    }
                    furniture.Userinfo = HttpContext.Session.GetInt32("Customer_Id");
                    furniture.Fdate = DateTime.Now;
                    _context.Update(furniture);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("AllAds", "Ads");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FurnitureExists(furniture.Fid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "City", furniture.Address);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", furniture.Userinfo);
            return View(furniture);
        }

        // GET: Furnitures/Delete/5
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
            var furniture = await _context.Furnitures
                .Include(f => f.AddressNavigation)
                .Include(f => f.UserinfoNavigation)
                .FirstOrDefaultAsync(m => m.Fid == id);
            if (furniture == null)
            {
                return NotFound();
            }

            return View(furniture);
        }

        // POST: Furnitures/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            var furniture = await _context.Furnitures.FindAsync(id);
            _context.Furnitures.Remove(furniture);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllAds", "Ads");
        }

        private bool FurnitureExists(decimal id)
        {
            return _context.Furnitures.Any(e => e.Fid == id);
        }
    }
}
