using System.Configuration;

namespace ReKreator.HtmlParser.Config.Models
{
    public class ParserConfig : ConfigurationSection
    {
        [ConfigurationProperty("concertLink")]
        public string ConcertUrl
        {
            get => (string)this["concertLink"];
            set => this["concertLink"] = value;
        }

        [ConfigurationProperty("spectacleLink")]
        public string SpectacleUrl
        {
            get => (string)this["spectacleLink"];
            set => this["spectacleLink"] = value;
        }

        [ConfigurationProperty("movieLink")]
        public string MovieUrl
        {
            get => (string)this["movieLink"];
            set => this["movieLink"] = value;
        }
    }
}