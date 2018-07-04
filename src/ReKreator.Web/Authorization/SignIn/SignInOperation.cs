using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using NLog;
using ReKreator.Common.Operations;
using ReKreator.Data.Models;
using ReKreator.Web.Models;

namespace ReKreator.Web.Authorization.SignIn
{
    public class SignInOperation : ISignInOperation
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly UserManager<User> userManager;
        private readonly IAuthenticationManager authManager;
        private readonly CookieAuthenticationOptions cookie;

        public SignInOperation(UserManager<User> userManager, IAuthenticationManager authManager, CookieAuthenticationOptions cookie)
        {
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));

            if (authManager == null)
                throw new ArgumentNullException(nameof(authManager));

            if (cookie == null)
                throw new ArgumentNullException(nameof(cookie));

            this.userManager = userManager;
            this.authManager = authManager;
            this.cookie = cookie;
        }

        public async Task<OperationResult> SignInAsync(SignInModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                var user = model.Login.Contains("@")
                    ? await userManager.FindByEmailAsync(model.Login)
                    : await userManager.FindByNameAsync(model.Login);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var claim = await userManager.CreateIdentityAsync(user, cookie.AuthenticationType);
                    authManager.SignOut();
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    Logger.Info($"Info: user \"{user.Email}\" was authorized.");
                    return  OperationResult.Succeed();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e, "An error occured sign in operation.");
            }
            return OperationResult.Fail(Resources.Resources.SignInError);
        }
    }
}