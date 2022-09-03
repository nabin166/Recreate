using BankFull.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankFull.Controllers
{
    public class AccountController : Controller
    {
        private readonly TransferOffContext _context;

        public AccountController(TransferOffContext transferOffContext)
        {
            _context = transferOffContext;
        }
        public IActionResult Index(bool issuccess = false )
        {
            
            ViewBag.IsSuccess = issuccess;
           
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Email, string Password)
        {
            User user = _context.user.Where(x=>x.Email == Email).FirstOrDefault();


            ClaimsIdentity identity = null!;
            bool isAuthenticate = false;

            if (user != null)
            {
                if(user.Password == Password)
                {
                    string roless = _context.Roles.Where(x => x.Users.Where(x => x.Email == Email).Count() > 0).FirstOrDefault().Role1;
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, Email),
                        new Claim(ClaimTypes.Role, roless),
                        
                    },CookieAuthenticationDefaults.AuthenticationScheme );

                    isAuthenticate = true;

                    if (isAuthenticate)
                    {
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Account", new { issuccess = true });
                }
            }
            else
            {
               
                return RedirectToAction("Index","Account",new { issuccess = true });
            }


           
            return RedirectToAction("Index","Account");
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }
    }
}
