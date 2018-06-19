using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using ReKreator.Business.Core.ImageService;
using ReKreator.Business.Models;
using ReKreator.Data.Core.UnitOfWork;
using ReKreator.Data.Models;

namespace ReKreator.Business.Core.EventProviderFolder
{
    public class EventProvider : IEventProvider
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPosterService posterService;

        public EventProvider(IUnitOfWork unitOfWork, IPosterService posterService)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (posterService == null)
                throw new ArgumentNullException(nameof(posterService));
            this.unitOfWork = unitOfWork;
            this.posterService = posterService;
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            var events = unitOfWork.EventsRepository.GetAll();
            return events.Select(MapEventDto).ToList();
        }

        public IEnumerable<EventDTO> GetEvents(EventType eventType)
        {
            var events = unitOfWork.EventsRepository.GetAll().Where(p => p.EventType == eventType).ToList();
            return events.Select(MapEventDto).ToList();
        }

        private EventDTO MapEventDto(Event item)
        {
            var result = new EventDTO
            {
                EventName = item.EventName,
                Description = item.Description,
                PosterUrl = posterService.GetImage(item.Id),
                SmallPosterUrl = posterService.GetSmallImage(item.Id),
                SourceUrl = new Url(item.LinkToSource),
                Type = item.EventType
            };
            return result;
        }
    }
}
