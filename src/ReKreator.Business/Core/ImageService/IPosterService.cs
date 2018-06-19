using System.Security.Policy;
using System.Threading.Tasks;

namespace ReKreator.Business.Core.ImageService
{
    public interface IPosterService
    {
        Task Upload(int id, Url imageLink);
        void Remove(int id);
        Url GetImage(int id);
        Url GetSmallImage(int id);
    }
}