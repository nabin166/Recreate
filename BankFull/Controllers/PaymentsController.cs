﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankFull.Models;

namespace BankFull.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly TransferOffContext _context;

        public PaymentsController(TransferOffContext context)
        {
            _context = context;
        }

        // GET: Payments

        public IActionResult PaymentTrack()
        {
            return View();

        }
        public async Task<IActionResult> Index()
        {
            List<tblMessage> tbllist = _context.tblMessages.ToList();

            ViewBag.UserSendig=tbllist;

          
            return View(_context.tblMessages.Include(x=>x.BankDetail).Include(x=>x.BankDetail.User).ToList());
        }
       

       

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paymentss == null)
            {
                return NotFound();
            }

            var payments = await _context.Paymentss
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            var Emails = User.Identity.Name;
            if (Emails != null)
            {
                int id = _context.user.Where(x => x.Email == Emails).FirstOrDefault().Id;

                ViewData["UserId"] = new SelectList(_context.user.Where(x => x.Id != id), "Id", "Name");
                return View();
            }
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Payment,UserId")] Payments payments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payments);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","UserDetail");
            }
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Address", payments.UserId);
            return View(payments);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paymentss == null)
            {
                return NotFound();
            }

            var payments = await _context.Paymentss.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Address", payments.UserId);
            return View(payments);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Payment,UserId")] Payments payments)
        {
            if (id != payments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsExists(payments.Id))
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
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Address", payments.UserId);
            return View(payments);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paymentss == null)
            {
                return NotFound();
            }

            var payments = await _context.Paymentss
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paymentss == null)
            {
                return Problem("Entity set 'TransferOffContext.Paymentss'  is null.");
            }
            var payments = await _context.Paymentss.FindAsync(id);
            if (payments != null)
            {
                _context.Paymentss.Remove(payments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsExists(int id)
        {
          return _context.Paymentss.Any(e => e.Id == id);
        }
    }
}
