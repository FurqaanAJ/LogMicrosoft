using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CallsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CallsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Calls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Call.ToListAsync());
        }

        // GET: Calls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calls = await _context.Call
                .FirstOrDefaultAsync(m => m.CallID == id);
            if (calls == null)
            {
                return NotFound();
            }

            return View(calls);
        }

        // GET: Calls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CallID,StudentID,TechID,SubjectLine,Description,Priority,Status,Comment,LogDate,CloseDate")] Calls calls)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calls);
        }

        // GET: Calls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calls = await _context.Call.FindAsync(id);
            if (calls == null)
            {
                return NotFound();
            }
            return View(calls);
        }

        // POST: Calls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CallID,StudentID,TechID,SubjectLine,Description,Priority,Status,Comment,LogDate,CloseDate")] Calls calls)
        {
            if (id != calls.CallID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallsExists(calls.CallID))
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
            return View(calls);
        }

        // GET: Calls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calls = await _context.Call
                .FirstOrDefaultAsync(m => m.CallID == id);
            if (calls == null)
            {
                return NotFound();
            }

            return View(calls);
        }

        // POST: Calls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var calls = await _context.Call.FindAsync(id);
            _context.Call.Remove(calls);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallsExists(string id)
        {
            return _context.Call.Any(e => e.CallID == id);
        }
    }
}
