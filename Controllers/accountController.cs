using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hypster_tv.Controllers
{
    [Authorize]
    public class accountController : Controller
    {


        //
        // GET: /account/
        //----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //----------------------------------------------------------------------------------------------------------





        //
        // POST: /Account/Login
        //----------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(hypster_tv.ViewModels.LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                hypster_tv_DAL.memberManagement membersManager = new hypster_tv_DAL.memberManagement();
                if (membersManager.ValidateUser(model.UserName, model.Password))
                {

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe); // need to save user guid
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        //----------------------------------------------------------------------------------------------------------





        //
        // GET: /Account/LogOff
        //----------------------------------------------------------------------------------------------------------
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        //----------------------------------------------------------------------------------------------------------



    }
}
