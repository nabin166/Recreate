using BankFull.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankFull.Controllers
{

    public class IndexController : Controller
    {
        private readonly TransferOffContext _context;

        public IndexController(TransferOffContext transferOffContext)
        {
            _context = transferOffContext;
        }


        //Not_Complete_View
        public async Task<IActionResult> Index()
        {


            return _context.tblMessages != null ?

             View(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Include(x => x.tblMessage.BankDetail.User).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() >= 1).Where(x => x.User.Role.Role1 == "Agent").ToListAsync()) :

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }

        //Complete_View

        public async Task<IActionResult> CompleteAsync()
        {


            return _context.tblMessages != null ?

                PartialView(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Include(x => x.tblMessage.BankDetail.User).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() == 0).Where(x => x.User.Role.Role1 == "Agent").ToListAsync()) :

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }

        public async Task<IActionResult> FinalMessageAsync()
        {


            List<tblMessage> tbl = _context.tblMessages.ToList();
            List<PhotoSend> photosen = _context.PhotoSends.ToList();
            List<BankDetail> bankdet = _context.BankDetails.ToList();

            List<PhotoSendModel> joins = (from t in tbl
                                          join p in photosen on t.Id equals p.MessageId
                                          join b in bankdet on t.BankId equals b.Id
                                          select new PhotoSendModel()
                                          {
                                              tbl = t,
                                              photosen = p,
                                              bankdet = b,
                                          }).ToList();

            string email = User.Identity.Name;
            int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;



            ViewData["bankAdmin"] = new SelectList(_context.AdminBanks.Where(x => x.Ammount < 600000), "Id", "CheckName");

            return _context.tblMessages != null ?

                PartialView(joins) :

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }
        /// <summary>
        ///----- it is going to be hide it is process complete section which is located in user view.(Message Complete tab)---------
        /// </summary>
        /// <returns></returns>

        //Bool False in message table
        public async Task<IActionResult> ProcessComplete()
        {
            List<tblMessage> tbl = _context.tblMessages.ToList();
            List<PhotoSend> photosen = _context.PhotoSends.ToList();
            List<BankDetail> bankdet = _context.BankDetails.ToList();
            List<User> user = _context.user.ToList();

            List<PhotoSendModel> joins = (from t in tbl
                                          join p in photosen on t.Id equals p.MessageId
                                          join b in bankdet on t.BankId equals b.Id
                                          join u in user on b.User.Email equals u.Email
                                          select new PhotoSendModel()
                                          {
                                              tbl = t,
                                              photosen = p,
                                              bankdet = b,
                                              user = u,
                                          }).ToList();

            string email = User.Identity.Name;
            int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;



            ViewData["bankAdmin"] = new SelectList(_context.AdminBanks.Where(x => x.Ammount < 600000), "Id", "CheckName");

            return _context.tblMessages != null ?

                PartialView(joins) :

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }


        //Bool True in message table
        public async Task<IActionResult> Completebooltrue()
        {
            string email = User.Identity.Name;
            int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;

            return _context.tblMessages != null ?

                  PartialView(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Where(x => x.tblMessage.completed == true).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() == 0).Where(x => x.User.Role.Role1 == "User").Where(x => x.tblMessage.BankDetail.UserId == uid).ToListAsync()) :

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }

        public async Task<IActionResult> CompletebooltrueAdmin()
        {


            return _context.tblMessages != null ?

                  PartialView(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Where(x => x.tblMessage.completed == true).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() == 0).Where(x => x.User.Role.Role1 == "User").ToListAsync()) :

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }

        //Complete wala

        public async Task<IActionResult> Processing()
        {
            string email = User.Identity.Name;
            int uid = _context.user.Where(x => x.Email == email).FirstOrDefault().Id;

            return _context.tblMessages != null ?

                PartialView(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() >= 1).Where(x => x.User.Role.Role1 == "User").Where(x => x.tblMessage.BankDetail.UserId == uid).ToListAsync()) :



                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }



    }

    internal class PhotoSendModel
    {
        public tblMessage tbl;
        public PhotoSend photosen;
        public BankDetail bankdet;
        public User user;
    }

}
