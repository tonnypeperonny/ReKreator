using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ReKreator.Web.Authorization.SignIn;
using ReKreator.Web.Authorization.SignOut;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Helpers;
using ReKreator.Web.Models;

namespace ReKreator.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISignInOperation signInManager;
        private readonly ISignOutOperation signOutManager;
        private readonly ISignUpOperation signUpManager;

        public AccountController(ISignUpOperation signUpManager, ISignOutOperation signOutManager, ISignInOperation signInManager)
        {
            if (signUpManager == null)
                throw new ArgumentNullException(nameof(signUpManager));

            if (signOutManager == null)
                throw new ArgumentNullException(nameof(signOutManager));

            if (signInManager == null)
                throw new ArgumentNullException(nameof(signInManager));

            this.signUpManager = signUpManager;
            this.signOutManager = signOutManager;
            this.signInManager = signInManager;
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

            if (!signUpResult.Succedeed)
            {
                ModelState.AddError(signUpResult.Content.Errors.ToList());
                return View("SignUp", model);
            }

            return RedirectToAction("SignIn", "Account");
        }

        [HttpGet]
        public ActionResult SignIn() => View("SignIn");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var operationResult = await signInManager.SignInAsync(model);
                if (!operationResult.Succedeed)
                {
                    ModelState.AddError(operationResult.Message);
                }
                else
                {
                    return RedirectToAction("DisplayAllFeaturedUserEvents", "Content");
                }
            }
            return View("SignIn", model);
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            signOutManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}