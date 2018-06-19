using System;
using ReKreator.Data.Core.Repository;
using ReKreator.Data.Models;

namespace ReKreator.Data.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Event> EventsRepository { get; set; }
        IRepository<Schedule> ScheduleRepository { get; set; }
        IRepository<Location> LocationRepository { get; set; }
        void SaveChanges();
    }
}