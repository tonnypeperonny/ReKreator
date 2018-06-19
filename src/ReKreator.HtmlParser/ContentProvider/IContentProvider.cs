using System.Collections.Generic;
using System.Threading.Tasks;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.ContentProvider
{
    public interface IContentProvider
    {
        Task<IEnumerable<Event>> GetContentAsync();
    }
}