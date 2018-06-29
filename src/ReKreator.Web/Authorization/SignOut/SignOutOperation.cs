using System;
using System.Web;
using Microsoft.Owin.Security;
using NLog;

namespace ReKreator.Web.Authorization.SignOut
{
    public class SignOutOperation : ISignOutOperation
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IAuthenticationManager authManager;

        public SignOutOperation(IAuthenticationManager authManager)
        {
            if(authManager == null)
                throw new ArgumentNullException(nameof(authManager));

            this.authManager = authManager;
        }

        public void SignOut()
        {
            authManager.SignOut();
            Logger.Info($" The user \"{HttpContext.Current.User.Identity.Name}\" left their account.");
        }
    }
}