using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReKreator.Business.Core.DbUpdate;
using ReKreator.Business.Core.ImageService;
using ReKreator.Data.Core.UnitOfWork;
using ReKreator.Data.Models;
using ReKreator.HtmlParser.Core.EventsProvider;
using ReKreator.HtmlParser.Models;
using Event = ReKreator.HtmlParser.Models.Event;
using EventType = ReKreator.HtmlParser.Models.EventType;
using Schedule = ReKreator.HtmlParser.Models.Schedule;

namespace ReKreator.Business.Tests.DbUpdate
{ 
    [TestFixture]
    public class DbUpdateServiceTests
    {
        private DbUpdateService dbUpdateService;
        private Mock<IEventsProvider> eventsProvider;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IPosterService> posterService;

        [SetUp]
        public void SetUp()
        {
            eventsProvider = new Mock<IEventsProvider>();
            unitOfWork = new Mock<IUnitOfWork>();
            posterService = new Mock<IPosterService>();

            var scheduleList = new List<Schedule>()
            {
                new Schedule()
                {
                    EventPlace = new Place(),
                    EventTime = new List<DateTime>()
                    {
                        new DateTime(2018, 06, 15),
                        new DateTime(1991, 06, 05)
                    }
                }
            };
            
            var events = new List<Event>()
            {
                new Event {Type = EventType.Concert, Name = "some1", Description = "some", PosterUrl = "some", SourceUrl = "some1", Schedules = scheduleList},
                new Event {Type = EventType.Concert, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()},
                new Event {Type = EventType.Concert, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()},
                new Event {Type = EventType.Movie, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()},
                new Event {Type = EventType.Movie, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()},
                new Event {Type = EventType.Movie, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()},
                new Event {Type = EventType.Spectacle, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()},
                new Event {Type = EventType.Spectacle, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()},
                new Event {Type = EventType.Spectacle, Name = "some", Description = "some", PosterUrl = "some", SourceUrl = "some", Schedules = new List<Schedule>()}
            };

            eventsProvider.Setup(p => p.GetEventsAsync()).ReturnsAsync(events);
            unitOfWork.Setup(p => p.EventsRepository).Verifiable();
            unitOfWork.Setup(p => p.LocationRepository).Verifiable();
            unitOfWork.Setup(p => p.ScheduleRepository).Verifiable();

            var dataModels = new List<Data.Models.Event>
            {
                new Data.Models.Event {Id = 2, EventName = "some1", LinkToSource = "some1"}
            };

            unitOfWork.Setup(p => p.EventsRepository.GetAll()).Returns(dataModels);
            unitOfWork.Setup(p => p.LocationRepository.GetAll()).Returns(new List<Location>());
            unitOfWork.Setup(p => p.ScheduleRepository.GetAll()).Returns(new List<Data.Models.Schedule>());
            
            dbUpdateService = new DbUpdateService(eventsProvider.Object, unitOfWork.Object, posterService.Object);
        }

        [Test]
        public void When_eventsProvider_null_should_throw_ArgumentNullException()
        {
            // Act
            Action act = () => new DbUpdateService(null, unitOfWork.Object, posterService.Object);
            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void When_unitOfWork_null_should_throw_ArgumentNullException()
        {
            // Act
            Action act = () => new DbUpdateService(eventsProvider.Object, null, posterService.Object);
            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void When_posterService_null_should_throw_ArgumentNullException()
        {
            // Act
            Action act = () => new DbUpdateService(eventsProvider.Object, unitOfWork.Object, null);
            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void When_all_arguments_correct_should_return_object()
        {
            // Assert
            dbUpdateService.Should().NotBeNull();
        }

        [Test]
        public async Task When_GetEventAsync_invoke_should_verify_unitOfWork()
        {
            await dbUpdateService.ExecuteUpdateAsync();
            unitOfWork.Verify(p => p.EventsRepository, Times.AtLeast(9));
        }
    }
}
