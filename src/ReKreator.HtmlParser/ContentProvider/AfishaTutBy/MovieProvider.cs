using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using NLog;
using ReKreator.HtmlParser.Config;
using ReKreator.HtmlParser.Core.HtmlProvider;
using ReKreator.HtmlParser.Models;
using AngleSharpParser = AngleSharp.Parser.Html;

namespace ReKreator.HtmlParser.ContentProvider.AfishaTutBy
{
    public class MovieProvider : IContentProvider
    {
        private readonly AngleSharpParser.HtmlParser parser;
        private readonly IHtmlProvider htmlProvider;
        private readonly IParserConfigProvider configProvider;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public MovieProvider(
            AngleSharpParser.HtmlParser parser, 
            IHtmlProvider htmlProvider, 
            IParserConfigProvider configProvider)
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));
            if (htmlProvider == null)
                throw new ArgumentNullException(nameof(htmlProvider));
            if (configProvider == null)
                throw new ArgumentNullException(nameof(configProvider));
            this.parser = parser;
            this.htmlProvider = htmlProvider;
            this.configProvider = configProvider;
        }

        public async Task<IEnumerable<Event>> GetContentAsync()
        {
            var baseUrl = configProvider.GetMovieUrl();

            var startDate = DateTime.Now;
            var stopDate = startDate.AddYears(4);

            var url = $"{baseUrl.Href}{startDate:yyyy-MM-dd}/{stopDate:yyyy-MM-dd}/";
            var source = await htmlProvider.GetHtmlPageAsync(new Url(url));
            if (source == null)
            {
                Logger.Info($"{url} is not avalible");
                return null;
            }
            var document = await parser.ParseAsync(source);

            var events = new List<Event>();

            var eventsCollection = document.QuerySelectorAll(".b-film-info");
            foreach (var item in eventsCollection)
            {
                var place = await GetPlace(item);

                var films = GetFilms(item);            

                foreach (var film in films)
                {
                    var filmReference = film.QuerySelector("a");
                    var sourceUrl = filmReference.GetAttribute("href");
                    var name = film.QuerySelector("[itemprop='summary']").TextContent;
                    var dates = film.QuerySelectorAll("time")
                        .Select(date => DateTime.Parse(date.GetAttribute("datetime"))).ToList();

                    var schedule = new Schedule()
                    {
                        EventPlace = place,
                        EventTime = dates
                    };

                    var schedulesCollection = new List<Schedule>()
                    {
                        schedule
                    };

                    var newEvent = new Event
                    {
                        Name = name,
                        SourceUrl = sourceUrl,
                        Schedules = schedulesCollection,
                        Type = EventType.Movie
                    };
                    events.Add(newEvent);
                }
            }

            var collection = RemoveDuplicates(events);
            var result = await PostRender(collection);

            return result;
        }

        private async Task<IEnumerable<Event>> PostRender(IEnumerable<Event> events)
        {
            var postRender = events.ToList();
            foreach (var item in postRender)
            {
                if (string.IsNullOrEmpty(item.SourceUrl)) continue;
                var source = await htmlProvider.GetHtmlPageAsync(new Url(item.SourceUrl));
                if (source == null)
                {
                    Logger.Info($"{item.SourceUrl} is not avalible");
                }
                var document = await parser.ParseAsync(source);

                item.PosterUrl = document.QuerySelector(".main_image")?.GetAttribute("src");
                item.Description = GetDescription(document);
                Thread.Sleep(1000);
            }

            return postRender;
        }

        private static IEnumerable<Event> RemoveDuplicates(IEnumerable<Event> events)
        {
            var result = new List<Event>();
            
            foreach (var itemEvent in events)
            {
                var item = result.FirstOrDefault(p =>
                    p.Name.Equals(itemEvent.Name) && p.SourceUrl.Equals(itemEvent.SourceUrl));
                if (item == null)
                {
                    result.Add(itemEvent);
                }
                else
                {
                    var itemSchedules = item.Schedules.ToList();
                    foreach (var schedule in itemEvent.Schedules)
                    {
                        var temp = itemSchedules.FirstOrDefault(p => p.EventPlace.Equals(schedule.EventPlace));
                        if (temp == null)
                        {
                            itemSchedules.Add(schedule);
                            item.Schedules = itemSchedules;
                        }
                        else
                        {
                            var times = temp.EventTime.ToList();
                            times.AddRange(schedule.EventTime);
                            itemSchedules.Remove(temp);
                            temp.EventTime = times;
                            itemSchedules.Add(temp);
                        }
                    }
                }
            }
            return result;
        }

        private static IEnumerable<IElement> GetFilms(IParentNode document)
        {
            var films = document.QuerySelectorAll(".film-name");
            return films;
        }

        private static IElement GetPlaceElement(IParentNode document)
        {
            var eventPlace = document.QuerySelectorAll("a")
                .FirstOrDefault(p => p.ParentElement.ClassName != null && p.ParentElement.ClassName == "name ");
            return eventPlace;
        }

        private async Task<Place> GetPlace(IParentNode document)
        {
            var placeElement = GetPlaceElement(document);

            var place = new Place
            {
                PlaceName = placeElement?.TextContent,
                PlaceUrl = placeElement?.GetAttribute("href")
            };

            if (string.IsNullOrEmpty(place.PlaceUrl))
                return place;

            var addressStream = await htmlProvider.GetHtmlPageAsync(new Url(place.PlaceUrl));
            var addressDocument = await parser.ParseAsync(addressStream);
            place.PlaceAddress = addressDocument.QuerySelector(".address")?.TextContent;

            return place;
        }

        private static string GetDescription(IParentNode document)
        {
            var description = document.QuerySelector("#event-description");

            var pageShare = description.QuerySelector(".b-page-share");
            var prmplace = description.QuerySelector(".b-prmplace-media");
            var note = description.QuerySelector(".note");

            if (pageShare != null) description.RemoveChild(pageShare);
            if (prmplace != null) description.RemoveChild(prmplace);
            if (note != null) description.RemoveChild(note);

            return description.InnerHtml;
        }
    }
}