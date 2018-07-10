using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Extensions;
using NLog;
using ReKreator.HtmlParser.Config;
using ReKreator.HtmlParser.Core.HtmlProvider;
using ReKreator.HtmlParser.Models;
using AngleSharpParser = AngleSharp.Parser.Html;

namespace ReKreator.HtmlParser.ContentProvider.AfishaTutBy
{
    public class SpectacleProvider : IContentProvider
    { 
        private readonly AngleSharpParser.HtmlParser parser;
        private readonly IHtmlProvider htmlProvider;
        private readonly IParserConfigProvider configProvider;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public SpectacleProvider(
            AngleSharpParser.HtmlParser parser, 
            IHtmlProvider htmlProvider, 
            IParserConfigProvider configProvider)
        {
            if (htmlProvider == null)
                throw new ArgumentNullException(nameof(htmlProvider));
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));
            if (configProvider == null)
                throw new ArgumentNullException(nameof(configProvider));
            this.htmlProvider = htmlProvider;
            this.parser = parser;
            this.configProvider = configProvider;
        }

        public async Task<IEnumerable<Event>> GetContentAsync()
        {
            var events = await GetAllEventsAsync();

            var eventsList = new List<Event>();
            foreach (var eventUrl in events)
            {
                var eventItem = await GetEventAsync(new Url(eventUrl));
                if (eventItem == null)
                {
                    Logger.Info($"{eventUrl} is not avalible");
                    continue;
                }
                eventItem.SourceUrl = eventUrl;
                eventsList.Add(eventItem);
                Thread.Sleep(1000);
            }

            return eventsList;
        }

        private async Task<IEnumerable<string>> GetAllEventsAsync()
        {
            var url = configProvider.GetSpectacleUrl();
            var source = await htmlProvider.GetHtmlPageAsync(url);
            if (source == null)
            {
                Logger.Info($"{url.Href} is not avalible");
                return new List<string>();
            }
            var document = await parser.ParseAsync(source);

            var events = document.QuerySelectorAll("[itemprop='url']");
            var result = events.Select(item => item.GetAttribute("href")).Distinct().ToList();
            return result;
        }

        private async Task<Event> GetEventAsync(Url url)
        {
            var source = await htmlProvider.GetHtmlPageAsync(url);
            var document = await parser.ParseAsync(source);

            var result = new Event()
            {
                Name = GetEventName(document),
                PosterUrl = GetPosterUrl(document),
                Description = GetDescription(document),
                Schedules = GetSchedule(document),
                Type = EventType.Spectacle
            };

            return result;
        }

        private static string GetEventName(IParentNode document)
        {
            var eventName = document.QuerySelector("#event-name");
            return eventName?.Text();
        }

        private static string GetPosterUrl(IParentNode document)
        {
            var poster = document.QuerySelector(".main_image");
            return poster?.GetAttribute("src");
        }

        private static string GetDescription(IParentNode document)
        {
            var description = document.QuerySelector("#event-description");

            var bPageShare = description.QuerySelector(".b-page-share");
            var prmplace = description.QuerySelector(".b-prmplace-media");
            var note = description.QuerySelector(".note");

            if (bPageShare != null) description.RemoveElement(bPageShare);
            if (prmplace != null) description.RemoveElement(prmplace);
            if (note != null) description.RemoveElement(note);

            return description.InnerHtml;
        }

        private static IElement GetPlaceElement(IParentNode document)
        {
            var eventPlace = document.QuerySelector(".b-event_place");
            return eventPlace;
        }

        private static IElement GetPlaceAddress(IParentNode document)
        {
            var address = document.QuerySelector(".b-event_address");
            return address;
        }

        private static IEnumerable<DateTime> GetDates(IParentNode document)
        {
            var days = document.QuerySelectorAll("[datetime]");
            var dates = days.Select(item => DateTime.Parse(item.GetAttribute("datetime"))).ToList();
            return dates;
        }

        private static Place GetPlace(IParentNode document)
        {
            var place = GetPlaceElement(document);
            var address = GetPlaceAddress(document);

            var result = new Place()
            {
                PlaceName = place?.Text(),
                PlaceUrl = place?.GetAttribute("href"),
            };
            result.PlaceAddress = address?.TextContent;

            return result;
        }

        private static IEnumerable<Schedule> GetSchedule(IParentNode document)
        {
            var place = GetPlace(document);
            var dates = GetDates(document);

            var result = new List<Schedule>
            {
                new Schedule()
                {
                    EventPlace = place,
                    EventTime = dates
                }
            };

            return result;
        }
    }
}
