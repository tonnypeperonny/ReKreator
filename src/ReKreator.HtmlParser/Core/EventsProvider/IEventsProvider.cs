using System.Collections.Generic;
using System.Threading.Tasks;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.Core.EventsProvider
{
    public interface IEventsProvider
    {
        Task<IEnumerable<Event>> GetEventsAsync();
    }
}