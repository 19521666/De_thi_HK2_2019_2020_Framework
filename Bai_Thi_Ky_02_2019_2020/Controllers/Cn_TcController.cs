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
    public class Cn_TcController : Controller
    {
        private readonly qlclContext _context;

        public Cn_TcController(qlclContext context)
        {
            _context = context;
        }

        // GET: Cn_Tc
        public async Task<IActionResult> Index()
        {
            var qlclContext = _context.CnTc.Include(c => c.MaCongNhanNavigation).Include(c => c.MaTrieuChungNavigation);
            return View(await qlclContext.ToListAsync());
        }

        // GET: Cn_Tc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cnTc = await _context.CnTc
                .Include(c => c.MaCongNhanNavigation)
                .Include(c => c.MaTrieuChungNavigation)
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (cnTc == null)
            {
                return NotFound();
            }

            return View(cnTc);
        }

        // GET: Cn_Tc/Create
        public IActionResult Create()
        {
            ViewData["MaCongNhan"] = new SelectList(_context.Congnhan, "MaCongNhan", "MaCongNhan");
            ViewData["MaTrieuChung"] = new SelectList(_context.Trieuchung, "MaTrieuChung", "MaTrieuChung");
            return View();
        }

        // POST: Cn_Tc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCongNhan,MaTrieuChung")] CnTc cnTc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cnTc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCongNhan"] = new SelectList(_context.Congnhan, "MaCongNhan", "MaCongNhan", cnTc.MaCongNhan);
            ViewData["MaTrieuChung"] = new SelectList(_context.Trieuchung, "MaTrieuChung", "MaTrieuChung", cnTc.MaTrieuChung);
            return View(cnTc);
        }

        // GET: Cn_Tc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cnTc = await _context.CnTc.FindAsync(id);
            if (cnTc == null)
            {
                return NotFound();
            }
            ViewData["MaCongNhan"] = new SelectList(_context.Congnhan, "MaCongNhan", "MaCongNhan", cnTc.MaCongNhan);
            ViewData["MaTrieuChung"] = new SelectList(_context.Trieuchung, "MaTrieuChung", "MaTrieuChung", cnTc.MaTrieuChung);
            return View(cnTc);
        }

        // POST: Cn_Tc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCongNhan,MaTrieuChung")] CnTc cnTc)
        {
            if (id != cnTc.MaCongNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cnTc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CnTcExists(cnTc.MaCongNhan))
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
            ViewData["MaCongNhan"] = new SelectList(_context.Congnhan, "MaCongNhan", "MaCongNhan", cnTc.MaCongNhan);
            ViewData["MaTrieuChung"] = new SelectList(_context.Trieuchung, "MaTrieuChung", "MaTrieuChung", cnTc.MaTrieuChung);
            return View(cnTc);
        }

        // GET: Cn_Tc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cnTc = await _context.CnTc
                .Include(c => c.MaCongNhanNavigation)
                .Include(c => c.MaTrieuChungNavigation)
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (cnTc == null)
            {
                return NotFound();
            }

            return View(cnTc);
        }

        // POST: Cn_Tc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cnTc = await _context.CnTc.FindAsync(id);
            _context.CnTc.Remove(cnTc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CnTcExists(string id)
        {
            return _context.CnTc.Any(e => e.MaCongNhan == id);
        }
    }
}
