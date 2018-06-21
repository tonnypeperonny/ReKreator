using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ReKreator.Data.Models;

namespace ReKreator.Web.Authorization.Validator
{
    public class SignUpUserValidator : IIdentityValidator<User>
    {
        private readonly UserManager<User> userManager;

        public SignUpUserValidator(UserManager<User> userManager)
        {
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));

            this.userManager = userManager ;
        }

        public async Task<IdentityResult> ValidateAsync(User user)
        {
            var errors = new List<string>();

            if (await userManager.FindByEmailAsync(user.Email) != null)
            {
                errors.Add(Resources.Resources.EmailError);
            }
            if (await userManager.FindByNameAsync(user.UserName) != null)
            {
                errors.Add(Resources.Resources.UserNameError);
            }
            return !errors.Any()? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
} 