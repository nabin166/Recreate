using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankFull.Models;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;


namespace BankFull.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class tblMessagesController : Controller
    {
        private readonly TransferOffContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public tblMessagesController(TransferOffContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }


        // GET: tblMessages
        public async Task<IActionResult> viewforadmin()
        {

            //   return View(_context.UserMessages.Include(x=>x.User).Include(x=>x.User.Role).Include(x=>x.tblMessage).Include(x=>x.tblMessage.BankDetail).ToList());  
            return View(_context.tblMessages.Include(x => x.UserMessages).Include(x => x.BankDetail).Include(x => x.BankDetail.User).Include(x => x.BankDetail.User.Role).OrderByDescending(x => x.Id).ToList());
        }







        public async Task<IActionResult> Index()
        {




            //  List<tblMessage> tbllist = _context.tblMessages.Where(x => x.UserMessages.Count() <= 1).ToList();
            /*  List<tblMessage> tbllist = _context.tblMessages.ToList();
              List<TransactionRate> ratelist = _context.TransactionRates.ToList();
              List<UserMessage> usermess = _context.UserMessages.ToList();
              List<BankDetail> bankdet = _context.BankDetails.ToList();
              List<User> usr = _context.user.ToList();
              List<Role> rol = _context.Roles.ToList(); */



            /////////
            /// 
            //   ViewData["data"] = data;
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {


                    /*

                       List<MessagerateViewModel> data = (from r in ratelist
                                                            join t in tbllist on r.Date equals t.Date
                                                            join u in usermess on t.Id equals u.MessageId
                                                            join b in bankdet on t.BankId equals b.Id
                                                            join e in usr on u.UserId equals e.Id
                                                            join o in rol on e.RoleId equals o.Id


                                                            select new MessagerateViewModel()
                                                            {
                                                                ratelist = r,
                                                                tbllist = t,
                                                                usermess = u,
                                                                bankdet = b,
                                                                usr = e,
                                                                rol = o


                                                            }).Where(x => x.usermess.User.Role.Role1 != "Agent").ToList(); */


                    // var data = _context.UserMessages.Where(x => x.User.Role.Role1 == "Agent").ToList();
                    // var atst = _context.UserMessages.Where(x => x.User.Role.Role1 == "User").ToList();

                    // atst.FindAll(x => x.MessageId).ToList();


                    //    var data = _context.tblMessages.Where(x => x.Id != ).ToList();












                    /*               
                         List<MessagerateViewModel> Assigned = (from r in ratelist
                                                            join t in tbllist on r.Date equals t.Date
                                                            join u in usermess on t.Id equals u.MessageId
                                                            join b in bankdet on t.BankId equals b.Id
                                                            join e in usr on u.UserId equals e.Id
                                                            join o in rol on e.RoleId equals o.Id


                                                            select new MessagerateViewModel()
                                                            {
                                                                ratelist = r,
                                                                tbllist = t,
                                                                usermess = u,
                                                                bankdet = b,
                                                                usr = e,
                                                                rol = o


                                                            }).Where(x=>x.usermess.User.Role.Role1 == "Agent").ToList();
                    */

                    var data = _context.tblMessages.Include(x => x.UserMessages).Include(x => x.BankDetail).Include(x => x.UserMessages).Include(x => x.BankDetail.User).Include(x => x.BankDetail.User.Role).OrderByDescending(x => x.Id).ToList();
                    /*   dynamic model = new System.Dynamic.ExpandoObject();
                       model.data = data;
                      // model.Assigned = Assigned;
                       */

                    // var Latestrateid = _context.TransactionRates.OrderByDescending(x => x.Id).First().Rate;
                    //  ViewData["rate"] = Latestrateid;



                    string email = User.Identity.Name;


                    //2022---------------------------9/30-------------------------



                    ViewData["usr"] = new SelectList(_context.user.Where(x => x.Role.Role1 == "Agent"), "Id", "Name");




                    return data != null ?
                          View(data) :

                          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");

                    //   return _context.tblMessages != null ?
                    //          View(await _context.UserMessages.Include(x=>x.User).Include(x=>x.tblMessage).Include(x => x.tblMessage.BankDetail).Where(x=>x.User.Role.Role1 != "Agent").ToListAsync()) :
                    //          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
                }
                else if (User.IsInRole("User"))
                {
                    string email = User.Identity.Name;
                    int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;

                    /*    List<MessagerateViewModel> data = (from r in ratelist
                                                           join t in tbllist on r.Date equals t.Date
                                                           join u in usermess on t.Id equals u.MessageId
                                                           join b in bankdet on t.BankId equals b.Id
                                                           join e in usr on u.UserId equals e.Id
                                                           join o in rol on e.RoleId equals o.Id


                                                           select new MessagerateViewModel()
                                                           {
                                                               ratelist = r,
                                                               tbllist = t,
                                                               usermess = u,
                                                               bankdet = b,
                                                               usr = e,
                                                               rol = o


                                                           }).Where(x => x.usermess.UserId == uid).ToList();


                      */
                    return _context.tblMessages != null ?
                          View(await _context.tblMessages.Include(x => x.UserMessages).Include(x => x.BankDetail).Include(x => x.UserMessages).Include(x => x.BankDetail.User).Include(x => x.BankDetail.User.Role).Where(x => x.BankDetail.UserId == uid).OrderByDescending(x => x.Id).ToListAsync()) :

                          Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
                }
                else if (User.IsInRole("Agent"))
                {
                    string email = User.Identity.Name;
                    int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
                    return _context.tblMessages != null ?
                          View(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Where(x => x.UserId == uid).OrderByDescending(x => x.Id).ToListAsync()) :

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

            //   List<BankViewModel> list = new SelectList(_context.BankDetails.)

            //BankViewModel vm = new BankViewModel();
            //vm.Bankid = uid;
            //  vm.Name_Account = _context.BankDetails.Where(x => x.Id == uid).FirstOrDefault().Name + _context.BankDetails.Where(x => x.Id == uid).FirstOrDefault().AccountName;
            //  ViewData["BankViewModel"] = new SelectList(vm, "Bankid", "Name_Account");

            //   ViewData["BankId"] = new SelectList(), "Bankid", "Name");





            //    string name = _context.BankDetails.Where(x => x.UserId == uid).FirstOrDefault().Name;
            //    string bank = _context.BankDetails.Where(x => x.UserId == uid).FirstOrDefault().AccountNumber;
            //    string b = name  + bank;





            ViewData["BankId"] = new SelectList(_context.BankDetails.Where(x => x.UserId == uid), "Id", "CheckName");


            return View();
        }
















        // POST: tblMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BankId,Amount,Date,Messages")] tblMessage tblMessage)
        {
            if (ModelState.IsValid)
            {

                /*       string folder = "photo/";

                       folder += Guid.NewGuid().ToString() + tblMessage.Document.FileName;

                       tblMessage.DocumentPath = folder;

                       string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                       await tblMessage.Document.CopyToAsync(new FileStream(serverFolder, FileMode.Create));  */
                tblMessage.completed = false;
               var abc = DateTime.Now.ToString("yyyy-MM-dd");
                int a = _context.TransactionRates.Where(x => x.Date == tblMessage.Date).Count();
                if (a != 0)
                {
                    decimal r = _context.TransactionRates.Where(x => x.Date == tblMessage.Date).FirstOrDefault().Rate;
                    tblMessage.Rate = r;
                }
                else
                    tblMessage.Rate = 0;

               // int a = _context.TransactionRates.Where(x => x.Date == abc).FirstOrDefault().Id;
             //   decimal r = _context.TransactionRates.Where(x => x.Id == a).FirstOrDefault().Rate;
              //  tblMessage.Rate = r; //
                _context.Add(tblMessage);
                await _context.SaveChangesAsync();


                string email = User.Identity.Name;
                int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;
                int msgid = tblMessage.Id;


                Transaction transaction = new Transaction();

                //yeha bata transaction rate nikalne .

                //  int abc = _context.TransactionRates.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                //  int amoun2 = (int)_context.TransactionRates.Where(p => p.Id == abc).FirstOrDefault().Rate;
                //  int? bcd = tblMessage.Amount * amoun2;
                //  transaction.CrAmount = bcd;
                //yeha samma lekhe ko 



                transaction.CrAmount = tblMessage.Amount;
                transaction.MessageId = msgid;
                transaction.Date = DateTime.Now.ToString("yyyy-MM-dd");



                _context.Add(transaction);

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

            int bankid = _context.BankDetails.Where(x => x.Id == id).FirstOrDefault().Id;
            //for boolean
          //  bool bankExists = false;

            //   bankDetails.DeleteConfirmed(bankid);
            // var result = new ControllerB().FileUploadMsgView("some string");
          //  var result = new BankDetailsController().DeleteConfirmed(bankid);



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

    /// <summary>
    /// //
    /// </summary>

    internal class MessagerateViewModel
    {
        public tblMessage tbllist { get; set; }
        public TransactionRate ratelist { get; set; }

        public UserMessage usermess { get; set; }
        public BankDetail bankdet { get; set; }
        public User usr { get; set; }
        public Role rol { get; set; }
    }




}
