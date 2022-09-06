using BankFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankFull.Controllers
{
    public class SenderController : Controller
    {
        private readonly TransferOffContext _context;

        public SenderController(TransferOffContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(int Mssgid ,int cid)
        {
            UserMessage userMessage = new UserMessage();
            userMessage.UserId = cid;
            userMessage.MessageId = Mssgid;
            _context.Add(userMessage);
            _context.SaveChanges();

            return RedirectToAction("Index", "Account");
        }

        [HttpPost]
        public  IActionResult Complete(int Amid,int mid)
        {
     
            
            if(_context.Transactions.Where(x=>x.MessageId == mid).Count()>0)
            {

                Transaction transaction = new Transaction();


                int query = _context.Transactions.Where(x => x.MessageId == mid).FirstOrDefault().Id;

                if (query != null)
                {
                    transaction.DrAmount = Amid;


                    _context.Update(transaction);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Account");
                }

               

            }
            return RedirectToAction("Index", "Account");

        }



    }
}
