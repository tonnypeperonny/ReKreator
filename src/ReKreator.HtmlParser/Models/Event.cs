using System;
using System.Collections.Generic;
using System.Linq;

namespace ReKreator.HtmlParser.Models
{
    public enum EventType { Movie, Spectacle, Concert }

    public class Event : IEquatable<Event>
    {
        public EventType Type { get; set; }
        public string Name { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public string SourceUrl { get; set; }

        public bool Equals(Event other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Type == other.Type && 
                   string.Equals(Name, other.Name) && 
                   string.Equals(PosterUrl, other.PosterUrl) && 
                   string.Equals(Description, other.Description) && Equals(Schedules, other.Schedules) && 
                   string.Equals(SourceUrl, other.SourceUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Event) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Type;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PosterUrl != null ? PosterUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);

                var hash = 17;
                foreach (var schedule in Schedules)
                {
                    hash *= 23;
                    hash += schedule.GetHashCode();
                }

                hashCode = (hashCode * 397) ^ (Schedules != null ? hash : 0);
                hashCode = (hashCode * 397) ^ (SourceUrl != null ? SourceUrl.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}