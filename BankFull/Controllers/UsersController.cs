using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankFull.Models;
using Microsoft.AspNetCore.Authorization;

using BCryptNet = BCrypt.Net.BCrypt;

namespace BankFull.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly TransferOffContext _context;

        public UsersController(TransferOffContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var transferOffContext = _context.user.Include(u => u.Role);


            return transferOffContext != null ?
            View(await transferOffContext.Where(x=>x.Role.Role1 != "Admin").OrderByDescending(x=>x.Id).ToListAsync()) :
            Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }
        //thapeko 
        public async Task<IActionResult> StatusAssign(string emails)
        {
            if (emails == null)
            {

            }
            else
            {
                var c = emails.Replace( '\n', ' ').Replace(" ", String.Empty); 
                
                int u2 = _context.user.Where(x => x.Email == c).FirstOrDefault().Id;
                

                if (u2 == null)
                {
                    //Something

                }
                else
                {
                    var user = await _context.user.FindAsync(u2);

                    if(user.Status == false)
                    {
                        user.Status = true;
                    }
                    else {
                        user.Status = false;
                    }
                   
                    _context.Update(user);
                    _context.SaveChanges();

                }

            }



            return View();
        }



        public async Task<IActionResult> Cancel(int msid, int Aid)
        {
            int d = Aid;
            var c = msid;

            if (d == 0)
            {

            }
            else
            {
                int b = _context.UserMessages.Where(x => x.UserId == d).Where(x => x.MessageId == msid).FirstOrDefault().Id;


                var user = await _context.UserMessages.FindAsync(b);
                if (user != null)
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                }



            }
            //  int a= _context.UserMessages.Where(x=>x.Id == Asmid).Count();

            return View();
        }

        //Thapeko 


        //Thapeko 


        public async Task<IActionResult> Reutrn(int msid)
        {
            string abc = User.Identity.Name;
            var c = msid;
           

            int a = _context.user.Where(x => x.Email == abc).FirstOrDefault().Id;

            var m = a;
            if (a == 0)
            {

            }
            else
            {
                int b = _context.UserMessages.Where(x => x.UserId == a).Where(x => x.MessageId == msid).FirstOrDefault().Id;


                var user = await _context.UserMessages.FindAsync(b);
                if (user != null)
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                }



            }
            //  int a= _context.UserMessages.Where(x=>x.Id == Asmid).Count();

            return View();
        }



        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Canceldoc(int Messageids, int Dramount)
        {

            

            if (_context.Transactions.Where(x => x.MessageId == Messageids).Count() > 0)
            {

                


                var query = _context.Transactions.Where(x => x.MessageId == Messageids).FirstOrDefault().Id;

                var c = _context.Transactions.Find(query);

                if (query != null)
                {

                    c.DrAmount = null;


                    _context.Update(c);
                    await _context.SaveChangesAsync();
                    PhotoSend photoSend = new PhotoSend();

                    var photosendid = _context.PhotoSends.Where(x=>x.MessageId == Messageids).FirstOrDefault().Id;
                    var photorem = await _context.PhotoSends.FindAsync(photosendid);
                    if (photorem != null)
                    {
                        _context.Remove(photorem);
                        _context.SaveChanges();
                    }


                    return RedirectToAction("Index", "Account");
                }



            }
            return RedirectToAction("Index", "Account");

        }



        // GET: Users/Details/5
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

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles.Where(x => x.Role1 != "Admin"), "Id", "Role1");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Email,Phone,Status,RoleId,Password")] User user)
        {
            if (ModelState.IsValid)
            {

               // User usr = new User();

                if(_context.user.Where(x=>x.Email == user.Email).Count() != 1) {


                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = passwordHash;
                    user.Status = false;


                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["error"] = "Username already exist";
                    return RedirectToAction("Register","Account");
                }


            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: Users/Edit/5
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
            ViewData["RoleId"] = new SelectList(_context.Roles.Where(x => x.Role1 != "Admin"), "Id", "Role1");
            return View(user);
        }

        // POST: Users/Edit/5
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

            //Model state remove from password .checking purpose.
            ModelState.Remove("Password");

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

        // GET: Users/Delete/5
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

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.user == null)
            {
                return Problem("Entity set 'TransferOffContext.user'  is null.");
            }
            var user = await _context.user.FindAsync(id);
            
            //  var tblmessage = _context.tblMessages.FirstOrDefault(m => m.Id == id);
          //  int a = (int)_context.UserMessages.Where(u => u.UserId == id).FirstOrDefault().MessageId;

          //  var usermess = _context.UserMessages.Where(u => u.UserId == id);
          //  var tbalmess = _context.tblMessages.Where(t => t.Id == a);
           // if(tbalmess != null)
           // {
           //     _context.tblMessages.RemoveRange(tbalmess);
          //  }
         //   if(usermess != null)
          //  {
             //   _context.UserMessages.RemoveRange(usermess);
           // }


          //  if
          //  var paymen = _context.Paymentss.Where(p => p.UserId == id);
          var bank = _context.BankDetails.Where(b => b.UserId == id);
            if(bank != null)
            {
                _context.BankDetails.RemoveRange(bank);
                _context.SaveChanges();
            }
         //   var usermess = _context.UserMessages.Where(u => u.UserId == id);
        /*    if(usermess != null)
            {
                _context.UserMessages.RemoveRange(usermess);
                _context.SaveChanges();
            }
            if(bank != null)
            {
                _context.BankDetails.RemoveRange(bank);
                _context.SaveChanges();
            } 
            if (paymen != null)
            {
                _context.Paymentss.RemoveRange(paymen);
                _context.SaveChanges();
               // _context.Paymentss.Remove(paymen); 
            }
            
            //var pay1 = _context.Paymentss.Where(p => p.UserId == id); */
          
         //   if (user != null)
         //   {
          //      _context.user.Remove(user);
          //      _context.SaveChanges();
          //  }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> AssignAsync( )
        {
            
            


            string email = User.Identity.Name;
            
            int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
          //  int b = _context.UserMessages.Where(x => x.UserId == uid).FirstOrDefault().Id;
      
            List<UserMessage> Assign = _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Include(x => x.tblMessage.BankDetail.User).Where(x=>x.tblMessage.BankDetail.User.Status == true).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() >= 1).Where(x => x.UserId == uid).ToList();
            //  List<UserMessage> AssignComplete = await this._context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Include(x => x.tblMessage.BankDetail.User).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() == 0).Where(x => x.UserId == uid).ToListAsync();






            // dynamic model = new System.Dynamic.ExpandoObject();

            //  model.Assign = Assign ;
            //    model.AssignComplete = AssignComplete ;






            return View(Assign);
           
        


        }

        public IActionResult Setting()
        {
            return View();
        }
        //--------Email-check-------
        [HttpPost]
        public JsonResult Emailcheck(string email , int cid)
        {
            var useremail = _context.user.Where(x => x.Id == cid).FirstOrDefault().Email;
            List<User> users = _context.user.Where(x => x.Email == email).Where(x=>x.Email != useremail).ToList();

           

            if (users.Count == 1)
            {
                bool data = false;
                return Json(data);
            }
            else
            {
                bool data = true;
                return Json(data);

            }


        }


        private bool UserExists(int id)
        {
          return (_context.user?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
internal class MessagerateViewimg
{
    public tblMessage tbllist { get; set; }
    public TransactionRate ratelist { get; set; }

    public UserMessage usermess { get; set; }
    public BankDetail bankdet { get; set; }
    public User usr { get; set; }
    public Role rol { get; set; }
}
