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
    public class ApartmentsadsController : Controller
    {
        private readonly ModelContext _context;

        public ApartmentsadsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Apartmentsads
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Apartmentsads.Include(a => a.AddressNavigation).Include(a => a.DurationNavigation).Include(a => a.UserinfoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Apartmentsads/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
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
        public async Task<IActionResult> Create([Bind("Adid,Adtitel,Addate,Descriptions,Price,Numofperson,Numofroom,Numofbed,Address,Street,BuildingNumber,Electricitybillprice,Waterbillprice,Duration,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Userinfo")] Apartmentsad apartmentsad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartmentsad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid", apartmentsad.Address);
            ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Id", apartmentsad.Duration);
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

            var apartmentsad = await _context.Apartmentsads.FindAsync(id);
            if (apartmentsad == null)
            {
                return NotFound();
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid", apartmentsad.Address);
            ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Id", apartmentsad.Duration);
            ViewData["Userinfo"] = new SelectList(_context.Users, "Userid", "Userid", apartmentsad.Userinfo);
            return View(apartmentsad);
        }

        // POST: Apartmentsads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Adid,Adtitel,Addate,Descriptions,Price,Numofperson,Numofroom,Numofbed,Address,Street,BuildingNumber,Electricitybillprice,Waterbillprice,Duration,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Userinfo")] Apartmentsad apartmentsad)
        {
            if (id != apartmentsad.Adid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartmentsad);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["Address"] = new SelectList(_context.Addresses, "Addresid", "Addresid", apartmentsad.Address);
            ViewData["Duration"] = new SelectList(_context.Durations, "Id", "Id", apartmentsad.Duration);
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

        // POST: Apartmentsads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var apartmentsad = await _context.Apartmentsads.FindAsync(id);
            _context.Apartmentsads.Remove(apartmentsad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentsadExists(decimal id)
        {
            return _context.Apartmentsads.Any(e => e.Adid == id);
        }
    }
}
