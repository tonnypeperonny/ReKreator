using Microsoft.AspNet.Identity;
using ReKreator.Common.Operations;
using ReKreator.Web.Models;

namespace ReKreator.Web.Authorization.SignUp
{
    public interface ISignUpOperation
    {
        OperationResult<IdentityResult> SignUp(SignUpModel model);
    }
}