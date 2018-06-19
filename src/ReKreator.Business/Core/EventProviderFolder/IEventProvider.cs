using System.Collections.Generic;
using ReKreator.Business.Models;
using ReKreator.Data.Models;

namespace ReKreator.Business.Core.EventProviderFolder
{
    public interface IEventProvider
    {
        IEnumerable<EventDTO> GetEvents();
        IEnumerable<EventDTO> GetEvents(EventType eventType);
    }
}