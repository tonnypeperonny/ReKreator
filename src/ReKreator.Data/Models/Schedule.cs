using System;

namespace ReKreator.Data.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime CreatedOn { get; set; }

        public Event Event { get; set; }
        public Location Location { get; set; }
    }
}
