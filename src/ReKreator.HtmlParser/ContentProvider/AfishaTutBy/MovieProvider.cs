using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.ContentProvider.AfishaTutBy
{
    public class MovieProvider : IContentProvider
    {
        public Task<IEnumerable<Event>> GetContentAsync()
        {
            return Task.FromResult(Enumerable.Empty<Event>());
        }
    }
}
