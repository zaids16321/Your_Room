﻿using System;
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
    public class UsersController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UsersController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        // GET: Users
        public async Task<IActionResult> Index()
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");

            var users = await _context.Users.Include(l => l.Logins).Where(i => i.Userid == HttpContext.Session.GetInt32("Customer_Id")).FirstOrDefaultAsync();
            return View(users);
            //return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userid,FullName,Email,Password,Phonenumber,UserImage,Gender,Age,Usertype")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
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
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, User user )
        {
            ViewBag.Customer_Id = HttpContext.Session.GetInt32("Customer_Id");
            ViewBag.Customer_Name = HttpContext.Session.GetString("Customer_Name");
            ViewBag.Customer_Image = HttpContext.Session.GetString("Customer_Image");
            ViewBag.Customer_Email = HttpContext.Session.GetString("Customer_Email");
            if (id != user.Userid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (user.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot 
                        string fileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName; // sffjhfbvjhbjskdnklnklnlk_picture 
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName); // wwwroot/image/filename

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            user.ImageFile.CopyTo(fileStream);
                            
                        }
                        user.UserImage = fileName;
                        user.Gender= _context.Users.Where(i => i.Userid == user.Userid).Select(u => u.Gender).FirstOrDefault();
                        user.Usertype= _context.Users.Where(i => i.Userid == user.Userid).Select(u => u.Usertype).FirstOrDefault();
                        HttpContext.Session.SetString("Customer_Image",user.UserImage);
                        _context.Update(user);
                    await _context.SaveChangesAsync();
                    }
                    else
                    {
                        user.UserImage = HttpContext.Session.GetString("Customer_Image");
                        user.Gender = _context.Users.Where(i => i.Userid == user.Userid).Select(u => u.Gender).FirstOrDefault();
                        user.Usertype = _context.Users.Where(i => i.Userid == user.Userid).Select(u => u.Usertype).FirstOrDefault();
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
             
                    var login = _context.Logins.Where(u => u.Userid == id).FirstOrDefault();
                    if (user.Password != null)
                    {
                        login.Password = user.Password;
                    }

                    if (user.Email != null)
                    {
                        login.Email = user.Email;
                    }
                    _context.Update(login);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Userid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return View(user);

            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login", "Auth");
            //return RedirectToAction(nameof(Index));
        }

        private bool UserExists(decimal id)
        {
            return _context.Users.Any(e => e.Userid == id);
        }
    }
}
