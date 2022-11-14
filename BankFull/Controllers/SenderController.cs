using BankFull.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using BankFull.Controllers;

namespace BankFull.Controllers
{
    public class SenderController : Controller
    {
        private readonly TransferOffContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SenderController(TransferOffContext context, IWebHostEnvironment webHostEnvironment)
        {

            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public async  Task<IActionResult> Complete(int Asmid , int msid , IFormFile PhotoPath)
        {

         //   var basestr =  Convert.FromBase64String(pathfull);

      //  string basestr = Encoding.GetEncoding(28591).GetString(Convert.FromBase64String(pathfull));

            if (_context.Transactions.Where(x=>x.MessageId == msid).Count()>0)
            {

             //   Transaction transaction = new Transaction();


                var query = _context.Transactions.Where(x => x.MessageId == msid).FirstOrDefault().Id;

                var c = _context.Transactions.Find(query);

                if (query != null)
                {

                
                    c.DrAmount = Asmid;


                    _context.Update(c);
                   await _context.SaveChangesAsync();




                    PhotoSend photoSend = new PhotoSend();
                  
                    string folder = "PhotoSend/";


                    folder += Guid.NewGuid().ToString() + PhotoPath.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                   
                    await PhotoPath.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    

                    photoSend.MessageId = msid;
                    photoSend.Photo = folder;
                    _context.Add(photoSend);
                    _context.SaveChanges();


                    return RedirectToAction("Index", "Account");
                }

              



            }
            return RedirectToAction("Index", "Account");

        }


        [HttpPost]
        public async Task<JsonResult>  PreviewAsync(int cid)
        {
            if (cid != null)
            {


            //    var image = _context.tblMessages.Where(x => x.Id == cid).FirstOrDefault().DocumentPath;

              var image =  _context.PhotoSends.Where(x =>x.MessageId == cid).FirstOrDefault().Photo;


               
                return  Json(image);


            }
            else
            {
                return Json(null);
            }
           
            return Json(null) ;
           
        }



       

    }
}
