using System.Security.Policy;
using ReKreator.Data.Models;

namespace ReKreator.Business.Models
{
    public class EventDTO
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public EventType Type { get; set; }
        public Url PosterUrl { get; set; }
        public Url SmallPosterUrl { get; set; }
        public Url SourceUrl { get; set; }
    }
}
