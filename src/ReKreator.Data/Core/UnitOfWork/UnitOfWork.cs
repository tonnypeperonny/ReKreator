using System;
using ReKreator.Data.Context;
using ReKreator.Data.Core.Repository;
using ReKreator.Data.Models;

namespace ReKreator.Data.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReKreatorContext db;
        
        public UnitOfWork(
            ReKreatorContext db,
            IRepository<Event> eventsRepository,
            IRepository<Schedule> scheduleRepository,
            IRepository<Location> locationRepository)
        {
            if (db == null)
                throw new ArgumentNullException(nameof(db));
            EventsRepository = eventsRepository;
            ScheduleRepository = scheduleRepository;
            LocationRepository = locationRepository;
            this.db = db;
        }

        public IRepository<Event> EventsRepository { get; set; }
        public IRepository<Schedule> ScheduleRepository { get; set; }
        public IRepository<Location> LocationRepository { get; set; }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}