using System.Data.Entity.ModelConfiguration;
using ReKreator.Data.Models;

namespace ReKreator.Data.Context.FluentAPI
{
    internal class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            Property(p => p.EventName).HasMaxLength(256);
            HasMany(p => p.Schedules).WithOptional(c => c.Event);
        }
    }
}