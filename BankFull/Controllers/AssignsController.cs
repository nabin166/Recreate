using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankFull.Models;

namespace BankFull.Controllers
{
    public class AssignsController : Controller
    {
        private readonly TransferOffContext _context;

        public AssignsController(TransferOffContext context)
        {
            _context = context;
        }

        // GET: Assigns
        public async Task<IActionResult> Index()
        {
            var transferOffContext = _context.Assigns.Include(a => a.TblMessage);
            return View(await transferOffContext.ToListAsync());
        }

        // GET: Assigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assigns == null)
            {
                return NotFound();
            }

            var assign = await _context.Assigns
                .Include(a => a.TblMessage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assign == null)
            {
                return NotFound();
            }

            return View(assign);
        }

        // GET: Assigns/Create
        public IActionResult Create()
        {
            ViewData["Messageid"] = new SelectList(_context.tblMessages, "Id", "Id");
            return View();
        }

        // POST: Assigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Receiver_Name,Received_Amount,Messageid")] Assign assign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Messageid"] = new SelectList(_context.tblMessages, "Id", "Id", assign.Messageid);
            return View(assign);
        }

        // GET: Assigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assigns == null)
            {
                return NotFound();
            }

            var assign = await _context.Assigns.FindAsync(id);
            if (assign == null)
            {
                return NotFound();
            }
            ViewData["Messageid"] = new SelectList(_context.tblMessages, "Id", "Id", assign.Messageid);
            return View(assign);
        }

        // POST: Assigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Receiver_Name,Received_Amount,Messageid")] Assign assign)
        {
            if (id != assign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignExists(assign.Id))
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
            ViewData["Messageid"] = new SelectList(_context.tblMessages, "Id", "Id", assign.Messageid);
            return View(assign);
        }

        // GET: Assigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assigns == null)
            {
                return NotFound();
            }

            var assign = await _context.Assigns
                .Include(a => a.TblMessage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assign == null)
            {
                return NotFound();
            }

            return View(assign);
        }

        // POST: Assigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assigns == null)
            {
                return Problem("Entity set 'TransferOffContext.Assigns'  is null.");
            }
            var assign = await _context.Assigns.FindAsync(id);
            if (assign != null)
            {
                _context.Assigns.Remove(assign);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignExists(int id)
        {
          return (_context.Assigns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
