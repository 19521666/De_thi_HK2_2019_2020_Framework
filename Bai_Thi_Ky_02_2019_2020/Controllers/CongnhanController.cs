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
    public class CongnhanController : Controller
    {
        private readonly qlclContext _context;

        public CongnhanController(qlclContext context)
        {
            _context = context;
        }

        // GET: Congnhan
        public async Task<IActionResult> Index()
        {
            var qlclContext = _context.Congnhan.Include(c => c.MaDiemCachLyNavigation);
            return View(await qlclContext.ToListAsync());
        }

        // GET: Congnhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congnhan = await _context.Congnhan
                .Include(c => c.MaDiemCachLyNavigation)
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congnhan == null)
            {
                return NotFound();
            }

            return View(congnhan);
        }

        // GET: Congnhan/Create
        public IActionResult Create()
        {
            ViewData["MaDiemCachLy"] = new SelectList(_context.Diemcachly, "Madiemcachly", "Madiemcachly");
            return View();
        }

        // POST: Congnhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCongNhan,TenCongNhan,GioiTinh,NamSinh,NuocVe,MaDiemCachLy")] Congnhan congnhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congnhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDiemCachLy"] = new SelectList(_context.Diemcachly, "Madiemcachly", "Madiemcachly", congnhan.MaDiemCachLy);
            return View(congnhan);
        }

        // GET: Congnhan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congnhan = await _context.Congnhan.FindAsync(id);
            if (congnhan == null)
            {
                return NotFound();
            }
            ViewData["MaDiemCachLy"] = new SelectList(_context.Diemcachly, "Madiemcachly", "Madiemcachly", congnhan.MaDiemCachLy);
            return View(congnhan);
        }

        // POST: Congnhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCongNhan,TenCongNhan,GioiTinh,NamSinh,NuocVe,MaDiemCachLy")] Congnhan congnhan)
        {
            if (id != congnhan.MaCongNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congnhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongnhanExists(congnhan.MaCongNhan))
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
            ViewData["MaDiemCachLy"] = new SelectList(_context.Diemcachly, "Madiemcachly", "Madiemcachly", congnhan.MaDiemCachLy);
            return View(congnhan);
        }

        // GET: Congnhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congnhan = await _context.Congnhan
                .Include(c => c.MaDiemCachLyNavigation)
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congnhan == null)
            {
                return NotFound();
            }

            return View(congnhan);
        }

        // POST: Congnhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var congnhan = await _context.Congnhan.FindAsync(id);
            _context.Congnhan.Remove(congnhan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongnhanExists(string id)
        {
            return _context.Congnhan.Any(e => e.MaCongNhan == id);
        }
    }
}
