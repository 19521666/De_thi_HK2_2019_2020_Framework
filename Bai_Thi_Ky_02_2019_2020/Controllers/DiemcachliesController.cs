using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bai_Thi_Ky_02_2019_2020.Data;
using Bai_Thi_Ky_02_2019_2020.Models;

namespace Bai_Thi_Ky_02_2019_2020.Controllers
{
    public class DiemcachliesController : Controller
    {
        private readonly QLCLContext _context;

        public DiemcachliesController(QLCLContext context)
        {
            _context = context;
        }

        // GET: Diemcachlies
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiemCachLies.ToListAsync());
        }

        // GET: Diemcachlies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemcachly = await _context.DiemCachLies
                .FirstOrDefaultAsync(m => m.Madiemcachly == id);
            if (diemcachly == null)
            {
                return NotFound();
            }

            return View(diemcachly);
        }

        // GET: Diemcachlies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diemcachlies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madiemcachly,Tendiemcachly,Diachi")] Diemcachly diemcachly)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemcachly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diemcachly);
        }

        // GET: Diemcachlies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemcachly = await _context.DiemCachLies.FindAsync(id);
            if (diemcachly == null)
            {
                return NotFound();
            }
            return View(diemcachly);
        }

        // POST: Diemcachlies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Madiemcachly,Tendiemcachly,Diachi")] Diemcachly diemcachly)
        {
            if (id != diemcachly.Madiemcachly)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemcachly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemcachlyExists(diemcachly.Madiemcachly))
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
            return View(diemcachly);
        }

        // GET: Diemcachlies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemcachly = await _context.DiemCachLies
                .FirstOrDefaultAsync(m => m.Madiemcachly == id);
            if (diemcachly == null)
            {
                return NotFound();
            }

            return View(diemcachly);
        }

        // POST: Diemcachlies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diemcachly = await _context.DiemCachLies.FindAsync(id);
            _context.DiemCachLies.Remove(diemcachly);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemcachlyExists(string id)
        {
            return _context.DiemCachLies.Any(e => e.Madiemcachly == id);
        }
    }
}
