using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReKreator.HtmlParser.ContentProvider;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.Core.Handlers
{
    public class ContentProvidersFacade : IContentProvidersFacade
    {
        private readonly IContentProvider concertProvider;
        private readonly IContentProvider spectacleProvider;
        private readonly IContentProvider movieProvider;

        public ContentProvidersFacade(
            IContentProvider concertProvider,
            IContentProvider spectacleProvider,
            IContentProvider movieProvider)
        {
            if (concertProvider == null)
                throw new ArgumentNullException(nameof(concertProvider));
            if (spectacleProvider == null)
                throw new ArgumentNullException(nameof(spectacleProvider));
            if (movieProvider == null)
                throw new ArgumentNullException(nameof(movieProvider));
            this.concertProvider = concertProvider;
            this.spectacleProvider = spectacleProvider;
            this.movieProvider = movieProvider;
        }

        public async Task<IReadOnlyCollection<IEnumerable<Event>>> CreateContentProvidersCollectionAsync()
        {
            var list = new List<IEnumerable<Event>>
            {
                await concertProvider.GetContentAsync(),
                await movieProvider.GetContentAsync(),
                await spectacleProvider.GetContentAsync()
            };

            return list;
        }
    }
}