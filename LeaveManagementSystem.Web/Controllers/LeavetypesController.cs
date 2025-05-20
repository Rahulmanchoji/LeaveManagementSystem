using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeavetypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeavetypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Leavetypes
        public async Task<IActionResult> Index()
        {
            // var data = SELECT * FROM LeaveTypes
            var data = await _context.LeaveTypes.ToListAsync();
            return View(data);
        }

        // GET: Leavetypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavetype = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leavetype == null)
            {
                return NotFound();
            }

            return View(leavetype);
        }

        // GET: Leavetypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leavetypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NumberOfDays")] Leavetype leavetype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leavetype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leavetype);
        }

        // GET: Leavetypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavetype = await _context.LeaveTypes.FindAsync(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            return View(leavetype);
        }

        // POST: Leavetypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfDays")] Leavetype leavetype)
        {
            if (id != leavetype.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leavetype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeavetypeExists(leavetype.Id))
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
            return View(leavetype);
        }

        // GET: Leavetypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavetype = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leavetype == null)
            {
                return NotFound();
            }

            return View(leavetype);
        }

        // POST: Leavetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leavetype = await _context.LeaveTypes.FindAsync(id);
            if (leavetype != null)
            {
                _context.LeaveTypes.Remove(leavetype);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeavetypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
    }
}
