using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using NLog;
using ReKreator.Data.Models;
using ReKreator.Web.Models;

namespace ReKreator.Web.Authorization.SignUp
{
    public class SignUpOperation : ISignUpOperation
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly UserManager<User> userManager;

        public SignUpOperation(UserManager<User> userManager, IIdentityValidator<User> signUpUserValidator)
        {
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));

            if (signUpUserValidator == null)
                throw new ArgumentNullException(nameof(signUpUserValidator));
            
            this.userManager = userManager;
            this.userManager.UserValidator = signUpUserValidator;
        }

        public IdentityResult SignUp(SignUpModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                };
                
                var identityResult = userManager.Create(user, model.UserPassword);
                if (identityResult.Errors.Any())
                {
                    Logger.Warn($"Creation of {user.Email} was failed.");
                    return IdentityResult.Failed(identityResult.Errors.ToArray());
                }
                Logger.Info($"Creation of {user.Email} was succeed.");
            }
            catch (Exception e)
            {
                Logger.Error(e, "An error occured during user creation.");
            }
            return IdentityResult.Success;
        }
    }
}