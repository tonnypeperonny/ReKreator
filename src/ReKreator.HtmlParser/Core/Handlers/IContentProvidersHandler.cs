using System.Collections.Generic;
using System.Threading.Tasks;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.Core.Handlers
{
    public interface IContentProvidersFacade
    {
        Task<IReadOnlyCollection<IEnumerable<Event>>> CreateContentProvidersCollectionAsync();
    }
}