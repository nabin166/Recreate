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



    }
}
