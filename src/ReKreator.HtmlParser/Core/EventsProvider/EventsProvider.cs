using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReKreator.HtmlParser.Core.Handlers;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.Core.EventsProvider
{
    public class EventsProvider : IEventsProvider
    {
        private readonly IContentProvidersFacade contentProviderFactory;

        public EventsProvider(IContentProvidersFacade contentProviderFactory)
        {
            if (contentProviderFactory == null)
                throw new ArgumentNullException(nameof(contentProviderFactory));
            this.contentProviderFactory = contentProviderFactory;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            var contentPrividerCollection = await contentProviderFactory.CreateContentProvidersCollectionAsync();

            var eventsList = new List<Event>();
            foreach (var item in contentPrividerCollection)
            {
                var enumerable = eventsList.Concat(item);
                eventsList = enumerable.ToList();
            }

            return eventsList;
        }
    }
}
