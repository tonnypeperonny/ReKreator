using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ReKreator.Data.Context.FluentAPI;
using ReKreator.Data.Models;

namespace ReKreator.Data.Context
{
    public class ReKreatorContext : IdentityDbContext<User>
    {
        public static ReKreatorContext Create()
        {
            return new ReKreatorContext();
        }

        public ReKreatorContext()
            : base("ReKreatorDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new LocationConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}