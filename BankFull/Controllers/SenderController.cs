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
        public IActionResult Index(int id ,int msgid)
        {
            UserMessage userMessage = new UserMessage();
            userMessage.UserId = id;
            userMessage.MessageId = msgid;
            _context.Add(userMessage);
            _context.SaveChanges();

            return RedirectToAction("Index", "Account");
        }



    }
}
