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
    [Authorize]
    public class tblMessagesController : Controller
    {
        private readonly TransferOffContext _context;

        public tblMessagesController(TransferOffContext context)
        {
            _context = context;
        }

        // GET: tblMessages
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return _context.tblMessages != null ?
                          View(await _context.tblMessages.ToListAsync()) :
                          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
                }
                else if(User.IsInRole("User"))
                {
                    string email = User.Identity.Name;
                    int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
                    return _context.tblMessages != null ?
                          View(await _context.tblMessages.Where(x=>x.UserMessages.Where(x=>x.UserId == uid).Count()>0).ToListAsync() ) :
                          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
                }
            }
              return _context.tblMessages != null ? 
                          View(await _context.tblMessages.ToListAsync()) :
                          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }

        // GET: tblMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblMessages == null)
            {
                return NotFound();
            }

            var tblMessage = await _context.tblMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMessage == null)
            {
                return NotFound();
            }

            return View(tblMessage);
        }

        // GET: tblMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bank,Amount,Date,DocumentPath,Messages")] tblMessage tblMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMessage);
                await _context.SaveChangesAsync();


                string email = User.Identity.Name;
                int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
                int msgid = tblMessage.Id;

                UserMessage userMessage = new UserMessage();
                userMessage.UserId = uid;
                userMessage.MessageId = msgid;
                _context.Add(userMessage);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }

            

            return View(tblMessage);
        }

        // GET: tblMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblMessages == null)
            {
                return NotFound();
            }

            var tblMessage = await _context.tblMessages.FindAsync(id);
            if (tblMessage == null)
            {
                return NotFound();
            }
            return View(tblMessage);
        }

        // POST: tblMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bank,Amount,Date,DocumentPath,Messages")] tblMessage tblMessage)
        {
            if (id != tblMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblMessageExists(tblMessage.Id))
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
            return View(tblMessage);
        }

        // GET: tblMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblMessages == null)
            {
                return NotFound();
            }

            var tblMessage = await _context.tblMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMessage == null)
            {
                return NotFound();
            }

            return View(tblMessage);
        }

        // POST: tblMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblMessages == null)
            {
                return Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
            }
            var tblMessage = await _context.tblMessages.FindAsync(id);
            if (tblMessage != null)
            {
                _context.tblMessages.Remove(tblMessage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblMessageExists(int id)
        {
          return (_context.tblMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
