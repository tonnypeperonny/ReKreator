using System;
using System.Linq;
using System.Web.Mvc;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Helpers;
using ReKreator.Web.Models;

namespace ReKreator.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISignUpOperation signUpManager;
        
        public AccountController(ISignUpOperation signUpManager)
        {
            if (signUpManager == null)
                throw new ArgumentNullException(nameof(signUpManager));

            this.signUpManager = signUpManager;
        }

        [HttpGet]
        public ActionResult SignUp() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel model)
        {
            if (!ModelState.IsValid)
                return View("SignUp", model);

            var signUpResult = signUpManager.SignUp(model);

            if (!signUpResult.Succeeded)
            {
                ModelState.AddError(signUpResult.Errors.ToList());
                return View("SignUp", model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}