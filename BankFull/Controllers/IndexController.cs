using BankFull.Models;
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
    }
}
