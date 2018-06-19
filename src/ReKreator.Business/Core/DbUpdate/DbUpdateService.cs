using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using ReKreator.Business.Core.ImageService;
using ReKreator.Data.Core.UnitOfWork;
using ReKreator.Data.Models;
using ReKreator.HtmlParser.Core.EventsProvider;
using ReKreator.HtmlParser.Models;
using Event = ReKreator.HtmlParser.Models.Event;
using EventType = ReKreator.HtmlParser.Models.EventType;
using Schedule = ReKreator.HtmlParser.Models.Schedule;

namespace ReKreator.Business.Core.DbUpdate
{
    public class DbUpdateService : IDbUpdateService
    {
        private readonly IEventsProvider eventsProvider;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPosterService posterService;

        public DbUpdateService(IEventsProvider eventsProvider, IUnitOfWork unitOfWork, IPosterService posterService)
        {
            if (eventsProvider == null)
                throw new ArgumentNullException(nameof(eventsProvider));
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (posterService == null)
                throw new ArgumentNullException(nameof(posterService));
            this.eventsProvider = eventsProvider;
            this.unitOfWork = unitOfWork;
            this.posterService = posterService;
        }

        public async Task ExecuteUpdateAsync()
        {
            var events = await eventsProvider.GetEventsAsync();
            // update database information
            foreach (var item in events)
            {
                int itemId;
                var eventsList = unitOfWork.EventsRepository.GetAll().ToList();
                var @event = eventsList.FirstOrDefault(p =>
                    p.EventName.Equals(item.Name) && p.LinkToSource.Equals(item.SourceUrl));
                if (@event == null)
                {
                    itemId = CreateNewEvent(item);
                    await posterService.Upload(itemId, new Url(item.PosterUrl));
                }
                else
                {
                    @event.Description = item.Description;
                    unitOfWork.EventsRepository.Update(@event);
                    unitOfWork.SaveChanges();
                    itemId = @event.Id;
                }
                UpdateSchedule(itemId, item.Schedules);
            }
        }

        private void UpdateSchedule(int itemId, IEnumerable<Schedule> itemSchedules)
        {
            foreach (var schedule in itemSchedules)
            {
                var locationId = UpdateLocation(schedule.EventPlace);
                var dateList = unitOfWork.ScheduleRepository.GetAll().ToList();
                foreach (var time in schedule.EventTime)
                {
                    var scheduleTime = dateList.FirstOrDefault(
                        p => DateTime.Compare(p.EventTime, time) == 0 && 
                             (p.Event == null || p.Event.Id == itemId) && 
                             (p.Location == null || p.Location.Id == locationId));
                    if (scheduleTime != null) continue;
                    var newTime = new Data.Models.Schedule()
                    {
                        EventTime = time,
                        CreatedOn = DateTime.Now,
                        Event = unitOfWork.EventsRepository.GetItem(itemId),
                        Location = unitOfWork.LocationRepository.GetItem(locationId)
                    };
                    unitOfWork.ScheduleRepository.Create(newTime);
                    unitOfWork.SaveChanges();
                }
            }
        }

        private int UpdateLocation(Place item)
        {
            var locationsList = unitOfWork.LocationRepository.GetAll().ToList();
            var location = locationsList.FirstOrDefault(p =>
                (item.PlaceName?.Equals(p.LocationName) ?? false) &&
                (item.PlaceAddress?.Equals(p.Address) ?? false));
            int locationId;
            if (location == null)
            {
                var newLocation = new Location
                {
                    LocationName = item.PlaceName,
                    Address = item.PlaceAddress,
                    CreatedOn = DateTime.Now
                };
                unitOfWork.LocationRepository.Create(newLocation);
                unitOfWork.SaveChanges();
                locationId = newLocation.Id;
            }
            else
            {
                locationId = location.Id;
            }
            return locationId;
        }

        private int CreateNewEvent(Event item)
        {
            var newEvent = new Data.Models.Event()
            {
                EventName = item.Name,
                Description = item.Description,
                CreatedOn = DateTime.Now,
                LinkToSource = item.SourceUrl
            };
            switch (item.Type)
            {
                case EventType.Movie:
                    newEvent.EventType = Data.Models.EventType.Movie;
                    break;
                case EventType.Spectacle:
                    newEvent.EventType = Data.Models.EventType.Spectacle;
                    break;
                case EventType.Concert:
                    newEvent.EventType = Data.Models.EventType.Concert;
                    break;
            }
            unitOfWork.EventsRepository.Create(newEvent);
            unitOfWork.SaveChanges();
            return newEvent.Id;
        }
    }
}