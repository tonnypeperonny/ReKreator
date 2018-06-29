using System.Threading.Tasks;
using ReKreator.Common.Operations;
using ReKreator.Web.Models;

namespace ReKreator.Web.Authorization.SignIn
{
    public interface ISignInOperation
    {
        Task<OperationResult> SignInAsync(SignInModel model);
    }
}