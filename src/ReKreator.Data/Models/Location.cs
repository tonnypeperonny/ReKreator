using System;
using System.Collections.Generic;

namespace ReKreator.Data.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public Location()
        {
            Schedules = new List<Schedule>();
        }
    }
}
