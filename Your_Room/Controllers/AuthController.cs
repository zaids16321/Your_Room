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
    public class AuthController : Controller
    {

        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Register()
        {
            ViewBag.error = HttpContext.Session.GetString("message");
            HttpContext.Session.Remove("message");
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user, string Email, string password)
        {
            var user1 = _context.Logins.Where(x => x.Email == Email).SingleOrDefault();
            if (user1 != null)
            {

                HttpContext.Session.SetString("message", "Email already used");

                ViewBag.error = HttpContext.Session.GetString("message");

                ModelState.AddModelError(Email, "Usename already used");
                return View();
            }
            if (ModelState.IsValid)
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
                }
                HttpContext.Session.Remove("message");
                _context.Add(user);
                _context.SaveChangesAsync();
                Login userLogin = new Login();
                userLogin.Email = Email;
                userLogin.Password = password;

                userLogin.Userid = user.Userid;
                _context.Add(userLogin);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Register));
                return RedirectToAction("Login", "Auth");

            }
            return View(user);
        }


        [HttpPost]
        public IActionResult Login(Login login)
        {
            var auth = _context.Logins.Include(z => z.User).Where(x => x.Email == login.Email && x.Password == login.Password).SingleOrDefault();
            if (auth != null)
            {
                HttpContext.Session.Remove("messageLogIn");
                //HttpContext.Session.SetInt32("Admin_Id", (int)auth.Userid);
                //HttpContext.Session.SetString("Admin_Name", auth.Email);
                //HttpContext.Session.SetString("Admin_Image", auth.User.UserImage);
                HttpContext.Session.SetInt32("Customer_Id", (int)auth.Userid);
                HttpContext.Session.SetString("Customer_Name", auth.User.FullName);
                if (auth.User.UserImage != null)
                {
                    HttpContext.Session.SetString("Customer_Image", auth.User.UserImage);
                }
                HttpContext.Session.SetString("Customer_Email", auth.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.Session.SetString("messageLogIn", "Email or Password is wrong");
                ViewBag.error = HttpContext.Session.GetString("messageLogIn");
            }


            return View();
        }

        public IActionResult Login()
        {
            ViewBag.error = HttpContext.Session.GetString("messageLogIn");
            HttpContext.Session.Remove("messageLogIn");
            return View();
        }
        public IActionResult Logout()
        {

            //AuthenticationHttpContextExtensions.SignOutAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }

        private bool UserExists(decimal id)
        {
            return _context.Users.Any(e => e.Userid == id);
        }
    }
}
