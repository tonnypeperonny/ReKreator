using System.Data.Entity.ModelConfiguration;
using ReKreator.Data.Models;

namespace ReKreator.Data.Context.FluentAPI
{
    internal class LocationConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationConfiguration()
        {
            Property(p => p.LocationName).HasMaxLength(256);
            Property(p => p.Address).HasMaxLength(256);

            HasMany(p => p.Schedules).WithOptional(c => c.Location);
        }
    }
}
