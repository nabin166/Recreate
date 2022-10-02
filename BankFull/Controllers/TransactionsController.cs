using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankFull.Models;
using Microsoft.AspNetCore.Authorization;

namespace BankFull.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransferOffContext _context;

        public TransactionsController(TransferOffContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public IActionResult Index()
        {
           

            List<TransactionRate> transactionRates = _context.TransactionRates.ToList();
            List<Transaction> transactions = _context.Transactions.ToList();
            List<tblMessage> tblMessages = _context.tblMessages.ToList();
            List<BankDetail> bankDetails = _context.BankDetails.ToList();
            List<User> users = _context.user.ToList();

            List<TransactionModel> transactionModels =   ( from t in transactions
                                                        join tr in transactionRates on t.Date equals tr.Date
                                                        join tbl in tblMessages on t.MessageId equals tbl.Id
                                                        join b in bankDetails on tbl.BankId equals b.Id
                                                        join u in users on b.UserId equals u.Id
                                                        
                                                        


                                                        select new TransactionModel()
                                                        {
                                                            transactionRates = tr,
                                                            transactions = t,
                                                            tblMessage = tbl,
                                                            Users = u
                                                            


                                                        }).ToList();

            var c = 12;
           // var transferOffContext = _context.Transactions.Include(t => t.TblMessage).Include(t=>t.TblMessage.BankDetail.User);
            return View(transactionModels);
        }

        [Authorize(Roles = "never")]

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.TblMessage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }
        [Authorize(Roles = "never")]
        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "never")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,DrAmount,CrAmount,UserId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", transaction.MessageId);
            return View(transaction);
        }
        [Authorize(Roles = "never")]
        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", transaction.MessageId);
            return View(transaction);
        }
        [Authorize(Roles = "never")]
        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,DrAmount,CrAmount,UserId")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
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
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", transaction.MessageId);
            return View(transaction);
        }

        [Authorize(Roles = "never")]
        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.TblMessage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }
        [Authorize(Roles = "never")]
        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'TransferOffContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
          return (_context.Transactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    internal class TransactionModel
    {

        public TransactionRate transactionRates { get; set; }
        public Transaction transactions { get; set; }

        public tblMessage tblMessage { get; set; }
        public User Users { get; set; }  
    }
}
