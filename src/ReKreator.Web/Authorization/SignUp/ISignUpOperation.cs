using Microsoft.AspNet.Identity;
using ReKreator.Web.Models;

namespace ReKreator.Web.Authorization.SignUp
{
    public interface ISignUpOperation
    {
        IdentityResult SignUp(SignUpModel model);
    }
}