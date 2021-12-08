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
    public class TrieuchungsController : Controller
    {
        private readonly qlclContext _context;

        public TrieuchungsController(qlclContext context)
        {
            _context = context;
        }

        // GET: Trieuchungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trieuchung.ToListAsync());
        }

        // GET: Trieuchungs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trieuchung = await _context.Trieuchung
                .FirstOrDefaultAsync(m => m.MaTrieuChung == id);
            if (trieuchung == null)
            {
                return NotFound();
            }

            return View(trieuchung);
        }

        // GET: Trieuchungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trieuchungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTrieuChung,TenTrieuChung")] Trieuchung trieuchung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trieuchung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trieuchung);
        }

        // GET: Trieuchungs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trieuchung = await _context.Trieuchung.FindAsync(id);
            if (trieuchung == null)
            {
                return NotFound();
            }
            return View(trieuchung);
        }

        // POST: Trieuchungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTrieuChung,TenTrieuChung")] Trieuchung trieuchung)
        {
            if (id != trieuchung.MaTrieuChung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trieuchung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrieuchungExists(trieuchung.MaTrieuChung))
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
            return View(trieuchung);
        }

        // GET: Trieuchungs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trieuchung = await _context.Trieuchung
                .FirstOrDefaultAsync(m => m.MaTrieuChung == id);
            if (trieuchung == null)
            {
                return NotFound();
            }

            return View(trieuchung);
        }

        // POST: Trieuchungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trieuchung = await _context.Trieuchung.FindAsync(id);
            _context.Trieuchung.Remove(trieuchung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrieuchungExists(string id)
        {
            return _context.Trieuchung.Any(e => e.MaTrieuChung == id);
        }
    }
}
