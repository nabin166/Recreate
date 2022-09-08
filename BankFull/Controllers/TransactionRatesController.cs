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
    public class TransactionRatesController : Controller
    {
        private readonly TransferOffContext _context;

        public TransactionRatesController(TransferOffContext context)
        {
            _context = context;
        }

        // GET: TransactionRates
        public async Task<IActionResult> Index()
        {
              return _context.TransactionRates != null ? 
                          View(await _context.TransactionRates.ToListAsync()) :
                          Problem("Entity set 'TransferOffContext.TransactionRates'  is null.");
        }

        // GET: TransactionRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransactionRates == null)
            {
                return NotFound();
            }

            var transactionRate = await _context.TransactionRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transactionRate == null)
            {
                return NotFound();
            }

            return View(transactionRate);
        }

        // GET: TransactionRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rate,Date")] TransactionRate transactionRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionRate);
        }

        // GET: TransactionRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransactionRates == null)
            {
                return NotFound();
            }

            var transactionRate = await _context.TransactionRates.FindAsync(id);
            if (transactionRate == null)
            {
                return NotFound();
            }
            return View(transactionRate);
        }

        // POST: TransactionRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rate,Date")] TransactionRate transactionRate)
        {
            if (id != transactionRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionRateExists(transactionRate.Id))
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
            return View(transactionRate);
        }

        // GET: TransactionRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactionRates == null)
            {
                return NotFound();
            }

            var transactionRate = await _context.TransactionRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transactionRate == null)
            {
                return NotFound();
            }

            return View(transactionRate);
        }

        // POST: TransactionRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransactionRates == null)
            {
                return Problem("Entity set 'TransferOffContext.TransactionRates'  is null.");
            }
            var transactionRate = await _context.TransactionRates.FindAsync(id);
            if (transactionRate != null)
            {
                _context.TransactionRates.Remove(transactionRate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionRateExists(int id)
        {
          return (_context.TransactionRates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
