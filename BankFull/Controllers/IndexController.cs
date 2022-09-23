using BankFull.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

             View(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() >= 1).Where(x=>x.User.Role.Role1 == "Agent").ToListAsync()):

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }

        //Complete_View

        public async Task<IActionResult> CompleteAsync()
        {


            return _context.tblMessages != null ?

                PartialView(await _context.UserMessages.Include(x => x.User).Include(x => x.tblMessage).Include(x => x.tblMessage.BankDetail).Where(x => x.tblMessage.Transactions.Where(x => x.DrAmount == null).Count() == 0).Where(x => x.User.Role.Role1 == "Agent").ToListAsync()) :

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }

        public async Task<IActionResult> FinalMessageAsync()
        {

            
            List<tblMessage> tbl = _context.tblMessages.ToList();
            List<PhotoSend> photosen = _context.PhotoSends.ToList();

            List<PhotoSendModel> joins = (from t in tbl
                            join p in photosen on t.Id equals p.MessageId

                            select new PhotoSendModel()
                            {
                                tbl = t,
                                photosen = p,
                            }).ToList();


            return _context.tblMessages != null ?

                PartialView(joins):

                Problem("Entity set 'TransferOffContext.tblMessages'  is null.");
        }
    }

    internal class PhotoSendModel
    {
        public tblMessage tbl;
        public PhotoSend photosen;
    }

}
