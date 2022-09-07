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
      //  [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Complete(int Asmid,int msid)
        {
        
            
            if(_context.Transactions.Where(x=>x.MessageId == msid).Count()>0)
            {

             //   Transaction transaction = new Transaction();


                var query = _context.Transactions.Where(x => x.MessageId == msid).FirstOrDefault().Id;

                var c = _context.Transactions.Find(query);
               


                if (query != null)
                {
                    c.DrAmount = Asmid;


                    _context.Update(c);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Account");
                }

               

            }
            return RedirectToAction("Index", "Account");

        }



    }
}
