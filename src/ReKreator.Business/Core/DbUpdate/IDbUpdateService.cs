using System.Threading.Tasks;

namespace ReKreator.Business.Core.DbUpdate
{
    public interface IDbUpdateService
    {
        Task ExecuteUpdateAsync();
    }
}