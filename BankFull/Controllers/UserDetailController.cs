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
    public class UserDetailController : Controller
    {
        private readonly TransferOffContext _context;

        public UserDetailController(TransferOffContext context)
        {
            _context = context;
        }

       
        public IActionResult RetailerAgent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AmountC(int userid)
        {

            //  List<tblMessage> abc = _context.tblMessages.Where(x=>x.UserMessages.Where(x=>x.tblMessage)).Include(x=> x.BankDetail.User)
            List<UserMessage> abc = _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Include(x => x.tblMessage.BankDetail.User).Where(x => x.UserId == userid).OrderByDescending(x => x.Id).ToList();

            return PartialView(abc);
        }

        [HttpPost]
        public IActionResult PayAmountC(int users)
        {
            // Null vancha ta -------------------- //
            List<Payments> payments = _context.Paymentss.Where(x => x.User.Id == users).OrderByDescending(x => x.Id).ToList();



            return View(payments);
//return _context.Paymentss != null ?
  //                        View(_context.Paymentss.Where(x => x.User.Id == users).ToList()) :
  //
                          Problem("Null payment Here");
        }


        [HttpPost]
        public IActionResult Pay(int usr)
        {



            ViewData["UserId"] = new SelectList(_context.user.Where(x => x.Id == usr), "Id", "Name");


            return View();
        }


        [HttpPost]
        public IActionResult PayAmount(int userid)
        {

            
            return View(_context.user.Where(x => x.Id == userid).OrderByDescending(x => x.Id).ToList());
        }

     






        // GET: UserDetail
        public async Task<IActionResult> Index()
        {
           

            var email = User.Identity.Name;
            var id = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
           var transferOffContext = _context.user.Include(x=>x.BankDetails).Include(x=>x.UserMessages).ThenInclude(x=>x.tblMessage).Include(x=>x.Paymentss).Where(x=>x.Role.Role1 != "Admin").Include(u => u.Role);

        
            

            return View(await transferOffContext.ToListAsync());
        }


        public async Task<IActionResult> Wholesalerview()
        {
            var email = User.Identity.Name;
            var id = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
            var transferOffContext = _context.user.Include(x => x.BankDetails).Include(x => x.UserMessages).ThenInclude(x => x.tblMessage).Include(x => x.Paymentss).Where(x => x.Id != id).Include(u => u.Role);




            return View(await transferOffContext.ToListAsync());
        }

        // GET: UserDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: UserDetail/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            return View();
        }

        // POST: UserDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Email,Phone,Status,RoleId,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: UserDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // POST: UserDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Email,Phone,Status,RoleId,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: UserDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.user == null)
            {
                return Problem("Entity set 'TransferOffContext.user'  is null.");
            }
            var user = await _context.user.FindAsync(id);
            if (user != null)
            {
                _context.user.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return _context.user.Any(e => e.Id == id);
        }
    }
}
