using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FogachoA_EjercicioCF.Data;
using FogachoA_EjercicioCF.Models;

namespace FogachoA_EjercicioCF.Controllers
{
    public class BurguersController : Controller
    {
        private readonly FogachoA_EjercicioCFContext _context;

        public BurguersController(FogachoA_EjercicioCFContext context)
        {
            _context = context;
        }

        // GET: Burguers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Burguer.ToListAsync());
        }

        // GET: Burguers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burguer = await _context.Burguer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burguer == null)
            {
                return NotFound();
            }

            return View(burguer);
        }

        // GET: Burguers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burguers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,WithCheese,Precio")] Burguer burguer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burguer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burguer);
        }

        // GET: Burguers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burguer = await _context.Burguer.FindAsync(id);
            if (burguer == null)
            {
                return NotFound();
            }
            return View(burguer);
        }

        // POST: Burguers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio")] Burguer burguer)
        {
            if (id != burguer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burguer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurguerExists(burguer.Id))
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
            return View(burguer);
        }

        // GET: Burguers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burguer = await _context.Burguer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (burguer == null)
            {
                return NotFound();
            }

            return View(burguer);
        }

        // POST: Burguers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burguer = await _context.Burguer.FindAsync(id);
            if (burguer != null)
            {
                _context.Burguer.Remove(burguer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurguerExists(int id)
        {
            return _context.Burguer.Any(e => e.Id == id);
        }
    }
}
