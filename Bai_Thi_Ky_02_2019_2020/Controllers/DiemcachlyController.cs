using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bai_Thi_Ky_02_2019_2020.Models;

namespace Bai_Thi_Ky_02_2019_2020.Controllers
{
    public class DiemcachlyController : Controller
    {
        private readonly qlclContext _context;

        public DiemcachlyController(qlclContext context)
        {
            _context = context;
        }

        // GET: Diemcachly
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diemcachly.ToListAsync());
        }

        // GET: Diemcachly/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemcachly = await _context.Diemcachly
                .FirstOrDefaultAsync(m => m.Madiemcachly == id);
            if (diemcachly == null)
            {
                return NotFound();
            }

            return View(diemcachly);
        }

        // GET: Diemcachly/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diemcachly/Create
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

        // GET: Diemcachly/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemcachly = await _context.Diemcachly.FindAsync(id);
            if (diemcachly == null)
            {
                return NotFound();
            }
            return View(diemcachly);
        }

        // POST: Diemcachly/Edit/5
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

        // GET: Diemcachly/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemcachly = await _context.Diemcachly
                .FirstOrDefaultAsync(m => m.Madiemcachly == id);
            if (diemcachly == null)
            {
                return NotFound();
            }

            return View(diemcachly);
        }

        // POST: Diemcachly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diemcachly = await _context.Diemcachly.FindAsync(id);
            _context.Diemcachly.Remove(diemcachly);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemcachlyExists(string id)
        {
            return _context.Diemcachly.Any(e => e.Madiemcachly == id);
        }
    }
}
