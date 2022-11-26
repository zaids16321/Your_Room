using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Your_Room.Models;

namespace Your_Room.Controllers
{
    public class FurnituresController : Controller
    {
        private readonly ModelContext _context;

        public FurnituresController(ModelContext context)
        {
            _context = context;
        }

        // GET: Furnitures
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Furnitures.Include(f => f.AddressNavigation).Include(f => f.UserinfoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Furnitures/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

        // GET: Furnitures/Create
        public IActionResult Create()
        {
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid");
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid");
            return View();
        }

        // POST: Furnitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fid,Ftitel,Fdate,Descriptions,Price,Address,Street,BuildingNumber,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Userinfo")] Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(furniture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid", furniture.Address);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", furniture.Userinfo);
            return View(furniture);
        }

        // GET: Furnitures/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furnitures.FindAsync(id);
            if (furniture == null)
            {
                return NotFound();
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid", furniture.Address);
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

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(furniture);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid", furniture.Address);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var furniture = await _context.Furnitures.FindAsync(id);
            _context.Furnitures.Remove(furniture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FurnitureExists(decimal id)
        {
            return _context.Furnitures.Any(e => e.Fid == id);
        }
    }
}
