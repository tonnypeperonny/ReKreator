using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReKreator.HtmlParser.ContentProvider;
using ReKreator.HtmlParser.Core.Handlers;
using ReKreator.HtmlParser.Models;

namespace ReKreator.HtmlParser.Tests.Core
{
    [TestFixture]
    public class ContentProviderFactoryTests
    {
        private Mock<IContentProvider> concertProvider;
        private Mock<IContentProvider> spectacleProvider;
        private Mock<IContentProvider> moviesProvider;
        private ContentProvidersFacade contentProviderFactory;

        [SetUp]
        public void SetUp()
        {
            concertProvider = new Mock<IContentProvider>();
            spectacleProvider = new Mock<IContentProvider>();
            moviesProvider = new Mock<IContentProvider>();
            contentProviderFactory = new ContentProvidersFacade(
                concertProvider.Object, 
                spectacleProvider.Object, 
                moviesProvider.Object);
        }

        [Test]
        public void Constructor_should_return_object_if_arguments_correct()
        {
            // assert
            contentProviderFactory.Should().NotBeNull();
        }

        [Test]
        public void Constructor_should_throw_ArgumentNullException_if_first_argument_null()
        {
            // act
            Action provider = () => new ContentProvidersFacade(null, spectacleProvider.Object, moviesProvider.Object);
            // assert
            provider.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Constructor_should_throw_ArgumentNullException_if_second_argument_null()
        {
            // act
            Action provider = () => new ContentProvidersFacade(concertProvider.Object, null, moviesProvider.Object);
            // assert
            provider.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Constructor_should_throw_ArgumentNullException_if_third_argument_null()
        {
            // act
            Action provider = () => new ContentProvidersFacade(concertProvider.Object, spectacleProvider.Object, null);
            // assert
            provider.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task CreateContentProvidersCollectionAsync_should_return_events_collection()
        {
            // arrange
            var resultCollection = new List<IEnumerable<Event>>();

            var concerts = new List<Event> {new Event(), new Event()};
            var spectacles = new List<Event> {new Event()};
            var movies = new List<Event> {new Event(), new Event(), new Event()};

            resultCollection.Add(concerts);
            resultCollection.Add(spectacles);
            resultCollection.Add(movies);

            concertProvider.Setup(p => p.GetContentAsync()).ReturnsAsync(concerts);
            spectacleProvider.Setup(p => p.GetContentAsync()).ReturnsAsync(spectacles);
            moviesProvider.Setup(p => p.GetContentAsync()).ReturnsAsync(movies);

            // act
            var result = await contentProviderFactory.CreateContentProvidersCollectionAsync();

            // assert
            result.Should().BeEquivalentTo(resultCollection);
        }
    }
}
