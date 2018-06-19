using System;
using AngleSharp;
using ReKreator.HtmlParser.Config.Models;

namespace ReKreator.HtmlParser.Config
{
    public class ParserConfigProvider : IParserConfigProvider
    {
        private readonly ParserConfig config;

        public ParserConfigProvider(ParserConfig config)
        {
            if (config == null)
                throw new ArgumentNullException();
            this.config = config;
        }

        public Url GetConcertUrl() => new Url(config.ConcertUrl);
        public Url GetSpectacleUrl() => new Url(config.SpectacleUrl);
        public Url GetMovieUrl() => new Url(config.MovieUrl);
    }
}
