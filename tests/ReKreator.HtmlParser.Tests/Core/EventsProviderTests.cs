using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReKreator.HtmlParser.Core.EventsProvider;
using ReKreator.HtmlParser.Core.Handlers;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.Tests.Core
{
    [TestFixture]
    public class EventsProviderTests
    {
        private Mock<IContentProvidersFacade> contentProviderFactory;
        private EventsProvider eventsProvider;

        [SetUp]
        public void SetUp()
        {
            // arrange
            var testCaseCollection = new List<List<Event>>();
            var collection1 = new List<Event> {new Event(), new Event()};
            var collection2 = new List<Event> {new Event()};
            var collection3 = new List<Event> {new Event(), new Event(), new Event()};
            testCaseCollection.Add(collection1);
            testCaseCollection.Add(collection2);
            testCaseCollection.Add(collection3);
            
            contentProviderFactory = new Mock<IContentProvidersFacade>();
            contentProviderFactory.Setup(p => p.CreateContentProvidersCollectionAsync())
                .ReturnsAsync(testCaseCollection);

            eventsProvider = new EventsProvider(contentProviderFactory.Object);
        }

        [Test]
        public void Constructor_should_throw_argumentNullException_if_argument_is_null()
        {
            // act
            Action act = () => new EventsProvider(null);
            // assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Constructor_should_return_correct_object_if_arguments_is_correct()
        {
            //assert
            eventsProvider.Should().NotBeNull();
        }

        [Test]
        public async Task GetEventsAsync_should_merged_collection_at_one_with_six_elements()
        {
            // act
            var result = await eventsProvider.GetEventsAsync();
            // assert
            result.Should().HaveCount(6);
        }
    }
}
