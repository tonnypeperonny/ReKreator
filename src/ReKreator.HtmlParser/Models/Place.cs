using System;

namespace ReKreator.HtmlParser.Models
{
    public class Place : IEquatable<Place>
    {
        public string PlaceName { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceUrl { get; set; }

        public bool Equals(Place other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(PlaceName, other.PlaceName) && 
                   string.Equals(PlaceAddress, other.PlaceAddress) && 
                   string.Equals(PlaceUrl, other.PlaceUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Place) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (PlaceName != null ? PlaceName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PlaceAddress != null ? PlaceAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PlaceUrl != null ? PlaceUrl.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
