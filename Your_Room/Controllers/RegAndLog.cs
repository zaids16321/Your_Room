using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Your_Room.Models;

namespace Your_Room.Controllers
{
    public class RegAndLog : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public RegAndLog(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnviroment = webHostEnvironment;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register( User user, string Email, string password)
        {
            if (ModelState.IsValid)
            {
                string wwwrootPath = _webHostEnviroment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                string extension = Path.GetExtension(user.ImageFile.FileName);
                user.UserImage = fileName;
                string path = Path.Combine(wwwrootPath + "/images/" + fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await user.ImageFile.CopyToAsync(filestream);
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                var ListId = _context.Users.OrderByDescending(p => p.Userid).FirstOrDefault().Userid;
                Login login1 = new Login();
                if (user.Usertype == "student")
                {
                    login1.User.Usertype = "student";
                }
                else
                    login1.User.Usertype = "lessor";
                login1.Email = Email;
                login1.Password = password;
                login1.Userid = ListId;
                _context.Add(login1);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "RegAndLog");
            }
            return View(user);
        }


        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login( Login login)
        {
            var auth = _context.Logins.Include(z => z.User).Where(x => x.Email == login.Email && x.Password == login.Password).SingleOrDefault();
            if (auth != null)
            {
                switch (auth.User.Usertype)
                {
                    case "student":
                        HttpContext.Session.SetInt32("Admin_Id", (int)auth.Userid);
                        HttpContext.Session.SetString("Admin_Name", auth.Email);
                        HttpContext.Session.SetString("Admin_Image", auth.User.UserImage);
                        return RedirectToAction("admin", "Admin");
                    case "lessor":
                        HttpContext.Session.SetInt32("Customer_Id", (int)auth.Userid);
                        HttpContext.Session.SetString("Customer_Image", auth.User.UserImage);
                        HttpContext.Session.SetString("Customer_Name", auth.Email);
                        return RedirectToAction("user", "Home");
                }
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "RegAndLog");
        }
    }
}

