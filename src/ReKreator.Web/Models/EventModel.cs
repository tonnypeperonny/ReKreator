using System.Security.Policy;


namespace ReKreator.Web.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public Url EventPoster { get; set; }
        public bool IsFavorite { get; set; }
    }
}