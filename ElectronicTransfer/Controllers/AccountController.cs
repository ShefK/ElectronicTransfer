using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ElectronicTransfer.Models;

namespace ElectronicTransfer.Controllers
{
    
    public class AccountController : Controller
    {
        
        public AccountController()
        {
        }

        
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
          
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
            public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model.ClientNumber.Equals("45612378") && model.Password.Equals("test123"))
            {
                return RedirectToAction("Index", "Home", UrlParameter.Optional);
            }

            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            return View(model);
        }

       
        
      
    }
}
