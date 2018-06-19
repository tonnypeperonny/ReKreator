using System;
using System.Collections.Generic;

namespace ReKreator.Data.Models
{
    public enum EventType
    {
        Concert,
        Spectacle,
        Movie
    }

    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public EventType EventType { get; set; }
        public string Description { get; set; }
        public string LinkToSource { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public Event()
        {
            Schedules = new List<Schedule>();
        }
    }
}
