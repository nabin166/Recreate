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
    public class AdminBanksController : Controller
    {
        private readonly TransferOffContext _context;

        public AdminBanksController(TransferOffContext context)
        {
            _context = context;
        }

        public string GetSubstringByString(string a, string b, string c)
        {
            return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
        }


        public IActionResult BankLimit(decimal ammountAdmin, string adminbank1, int mid , int userid)
        {
            //   if(_context.AdminBanks.Where(x=>x.Date == DateTime.Now.ToString("yyyy-MM-dd"))){

            //  }

            // decimal Ammount = +ammountAdmin;



           string abc = GetSubstringByString("(", ")", adminbank1);
            

            int id = _context.AdminBanks.Where(x => x.AccountNumber == abc).FirstOrDefault().Id;
           var Amount1 = _context.AdminBanks.Where(x => x.Id == id).FirstOrDefault().Ammount;
            var date1 = _context.AdminBanks.Where(x => x.Id == id).FirstOrDefault().Date;
            var date2 = DateTime.Now.ToString("yyyy-MM-dd");
            if(date1 != date2)
            {
                var user = _context.AdminBanks.Find(id);
                user.Ammount = 0;
                user.Date = DateTime.Now.ToString("yyyy-MM-dd");

                _context.Update(user);
                _context.SaveChanges();

            }


       /*     var a = _context.AdminBanks.Where(x => x.Date != DateTime.Now.ToString("yyyy-MM-dd"));
            if (a != null)
            {
                var user =  _context.AdminBanks.Find(id);
                user.Ammount = 0;
                user.Date = DateTime.Now.ToString("yyyy-MM-dddd");
                
                _context.Update(user);
                _context.SaveChanges();
            } */

            Amount1 = Amount1 + ammountAdmin;
            if(Amount1 <= 6000000)
            {
                var c = _context.AdminBanks.Find(id);
                if (c != null) {
                    c.Ammount = Amount1;
                    _context.Update(c);
                    _context.SaveChanges();
                }
                var d = _context.tblMessages.Find(mid);
                if(d!= null)
                {
                    d.completed = true;
                    _context.Update(d);
                    _context.SaveChanges();
                }
                // ----------Don't know how much he/see can pay.----------//
                //-----------------We canont track payment according to the slip --------------------------//

                Payments payments = new Payments();
                payments.UserId = userid;
                payments.Payment = ammountAdmin;
                _context.Add(payments);
                _context.SaveChanges();


            }
            else
            {
                //Viewbag error tomorrow do
            }
           // bank.Ammount = ammountAdmin;



            return View();
        }

        // GET: AdminBanks
        public async Task<IActionResult> Index()
        {
              return View(await _context.AdminBanks.ToListAsync());
        }

        // GET: AdminBanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminBanks == null)
            {
                return NotFound();
            }

            var adminBank = await _context.AdminBanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminBank == null)
            {
                return NotFound();
            }

            return View(adminBank);
        }

        // GET: AdminBanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,Name,Ammount,AccountNumber")] AdminBank adminBank)
        {
            adminBank.Ammount = 0;
            if (ModelState.IsValid)
            {
                _context.Add(adminBank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminBank);
        }

        // GET: AdminBanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminBanks == null)
            {
                return NotFound();
            }

            var adminBank = await _context.AdminBanks.FindAsync(id);
            if (adminBank == null)
            {
                return NotFound();
            }
            return View(adminBank);
        }

        // POST: AdminBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,Name,Ammount,AccountNumber")] AdminBank adminBank)
        {
            if (id != adminBank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminBankExists(adminBank.Id))
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
            return View(adminBank);
        }

        // GET: AdminBanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminBanks == null)
            {
                return NotFound();
            }

            var adminBank = await _context.AdminBanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminBank == null)
            {
                return NotFound();
            }

            return View(adminBank);
        }

        // POST: AdminBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminBanks == null)
            {
                return Problem("Entity set 'TransferOffContext.AdminBanks'  is null.");
            }
            var adminBank = await _context.AdminBanks.FindAsync(id);
            if (adminBank != null)
            {
                _context.AdminBanks.Remove(adminBank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminBankExists(int id)
        {
          return _context.AdminBanks.Any(e => e.Id == id);
        }
    }
}
