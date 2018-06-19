using System;
using System.Collections.Generic;

namespace ReKreator.HtmlParser.Models
{
    public class Schedule : IEquatable<Schedule>
    {
        public Place EventPlace { get; set; }
        public IEnumerable<DateTime> EventTime { get; set; }

        public bool Equals(Schedule other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(EventPlace, other.EventPlace) && Equals(EventTime, other.EventTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Schedule) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 0;
                hashCode = (hashCode * 397) ^ (EventPlace != null ? EventPlace.GetHashCode() : 0);

                var hash = 17;
                foreach (var time in EventTime)
                {
                    hash *= 23;
                    hash += time.GetHashCode();
                }

                hashCode = (hashCode * 397) ^ (EventTime != null ? hash : 0);
                return hashCode;
            }
        }
    }
}
