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
    public class BankDetailsController : Controller
    {
        private readonly TransferOffContext _context;

        public BankDetailsController(TransferOffContext context)
        {
            _context = context;
        }

        // GET: BankDetails
        public async Task<IActionResult> Index()
        {
            var transferOffContext = _context.BankDetails.Include(b => b.User);
            return View(await transferOffContext.ToListAsync());
        }

        // GET: BankDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BankDetails == null)
            {
                return NotFound();
            }

            var bankDetail = await _context.BankDetails
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankDetail == null)
            {
                return NotFound();
            }

            return View(bankDetail);
        }

        // GET: BankDetails/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id");
            return View();
        }

        // POST: BankDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AccountNumber,AccountName,Address,AmountIn,AmountOut,TransactionLimit,UserId")] BankDetail bankDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", bankDetail.UserId);
            return View(bankDetail);
        }

        // GET: BankDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BankDetails == null)
            {
                return NotFound();
            }

            var bankDetail = await _context.BankDetails.FindAsync(id);
            if (bankDetail == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", bankDetail.UserId);
            return View(bankDetail);
        }

        // POST: BankDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AccountNumber,AccountName,Address,AmountIn,AmountOut,TransactionLimit,UserId")] BankDetail bankDetail)
        {
            if (id != bankDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankDetailExists(bankDetail.Id))
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
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", bankDetail.UserId);
            return View(bankDetail);
        }

        // GET: BankDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BankDetails == null)
            {
                return NotFound();
            }

            var bankDetail = await _context.BankDetails
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankDetail == null)
            {
                return NotFound();
            }

            return View(bankDetail);
        }

        // POST: BankDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BankDetails == null)
            {
                return Problem("Entity set 'TransferOffContext.BankDetails'  is null.");
            }
            var bankDetail = await _context.BankDetails.FindAsync(id);
            if (bankDetail != null)
            {
                _context.BankDetails.Remove(bankDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankDetailExists(int id)
        {
          return (_context.BankDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
