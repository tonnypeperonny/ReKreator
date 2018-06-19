using System.IO;
using System.Threading.Tasks;
using AngleSharp;

namespace ReKreator.HtmlParser.Core.HtmlProvider
{
    public interface IHtmlProvider
    {
        Task<Stream> GetHtmlPageAsync(Url url);
    }
}