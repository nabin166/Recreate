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
    [Authorize (Roles = "Admin,User")]
    public class tblMessagesController : Controller
    {
        private readonly TransferOffContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public tblMessagesController(TransferOffContext context , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: tblMessages
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    string email = User.Identity.Name;
                    ViewData["usr"] = new SelectList( _context.user.Where(x=>x.Role.Role1 == "Agent") , "Id", "Name");

                    return _context.tblMessages != null ?
                          View(await _context.UserMessages.Include(x=>x.User).Include(x=>x.tblMessage).Include(x => x.tblMessage.BankDetail).Where(x=>x.User.Role.Role1 != "Agent").ToListAsync()) :
                          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
                }
                else if(User.IsInRole("User"))
                {
                    string email = User.Identity.Name;
                    int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
                    return _context.UserMessages != null ?
                          View(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Where(x=>x.UserId == uid).ToListAsync()):
                    
                          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
                }
                else if (User.IsInRole("Agent"))
                {
                    string email = User.Identity.Name;
                    int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
                    return _context.tblMessages != null ?
                          View(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Where(x => x.UserId == uid).ToListAsync()) :

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
            string email = User.Identity.Name;
            int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
            ViewData["BankId"] = new SelectList(_context.BankDetails.Where(x=>x.UserId == uid), "Id", "Name");
            return View();
        }

        // POST: tblMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BankId,Amount,Date,DocumentPath,Messages,Document")] tblMessage tblMessage)
        {
            if (ModelState.IsValid)
            {
                if (tblMessage.Document != null)
                {
                    string folder = "photo/";

                    folder += Guid.NewGuid().ToString() + tblMessage.Document.FileName;

                    tblMessage.DocumentPath = folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await tblMessage.Document.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                    _context.Add(tblMessage);
                    await _context.SaveChangesAsync();


                    string email = User.Identity.Name;
                    int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
                    int msgid = tblMessage.Id;


                    Transaction transaction = new Transaction();
                    transaction.CrAmount = tblMessage.Amount;
                    transaction.MessageId = msgid;
                    transaction.Date = DateTime.Now.ToString();

                    _context.Add(transaction);

                    UserMessage userMessage = new UserMessage();
                    userMessage.UserId = uid;
                    userMessage.MessageId = msgid;
                    _context.Add(userMessage);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));

                }
              


               
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
