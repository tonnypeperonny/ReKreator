using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AngleSharp;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReKreator.HtmlParser.Config;
using ReKreator.HtmlParser.ContentProvider.AfishaTutBy;
using ReKreator.HtmlParser.Core.HtmlProvider;

namespace ReKreator.HtmlParser.Tests.ContentProviders
{
    [TestFixture]
    public class SpectacleProviderTests
    {
        private SpectacleProvider provider;
        private AngleSharp.Parser.Html.HtmlParser parser;
        private Mock<IHtmlProvider> htmlProvider;
        private Mock<IParserConfigProvider> parserConfig;

        [SetUp]
        public void SetUp()
        {
            parser = new AngleSharp.Parser.Html.HtmlParser();
            htmlProvider = new Mock<IHtmlProvider>();
            parserConfig = new Mock<IParserConfigProvider>();

            provider = new SpectacleProvider(parser, htmlProvider.Object, parserConfig.Object);
        }

        [Test]
        public void SpectacleProviderConstructor_should_return_object_if_all_arguments_correct()
        {
            // assert
            provider.Should().NotBeNull();
        }

        [Test]
        public void SpectacleProviderConstructor_should_throw_argumentNullException_if_first_argument_null()
        {
            // act
            Action act = () => new SpectacleProvider(null, htmlProvider.Object, parserConfig.Object);
            // assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SpectacleProviderConstructor_should_throw_argumentNullException_if_second_argument_null()
        {
            // act
            Action act = () => new SpectacleProvider(parser, null, parserConfig.Object);
            // assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SpectacleProviderConstructor_should_throw_argumentNullException_if_third_argument_null()
        {
            // act
            Action act = () => new SpectacleProvider(parser, htmlProvider.Object, null);
            // assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task GetContentAsync_should_return_empty_collection_if_categoryPage_without_events()
        {
            // arrange
            var url = new Url("http://concertPage.html");
            parserConfig.Setup(p => p.GetConcertUrl()).Returns(url);

            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName 
                = "ReKreator.HtmlParser.Tests.TestPages.ConcertCategory.PageWithoutEvents.html";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                htmlProvider.Setup(p => p.GetHtmlPageAsync(It.IsAny<Url>())).ReturnsAsync(stream);
                // act
                var result = await provider.GetContentAsync();
                // assert
                var eventsCount = result.Count();
                eventsCount.Should().BeGreaterOrEqualTo(0);
            }
        }

        [Test]
        public async Task GetContentAsync_should_return_collection_with_events_without_duplicates_if_categoryPage_with_events()
        {
            // arrange
            var url = new Url("http://concertPage.html");
            var urlPage1 = new Url("https://concertpage1/");
            var urlPage2 = new Url("https://concertpage2/");
            var urlPage3 = new Url("https://concertpage3/");
            parserConfig.Setup(p => p.GetSpectacleUrl()).Returns(url);

            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "ReKreator.HtmlParser.Tests.TestPages.ConcertCategory.PageWithEvents.html";
            using (var stream1 = assembly.GetManifestResourceStream(resourceName))
            {
                htmlProvider.Setup(p => p.GetHtmlPageAsync(It.Is<Url>(i => i.Href.Contains(url.Href))))
                    .ReturnsAsync(stream1);

                const string page1Name = "ReKreator.HtmlParser.Tests.TestPages.ConcertCategory.Page1.html";
                var stream2 = assembly.GetManifestResourceStream(page1Name);
                htmlProvider.Setup(p => p.GetHtmlPageAsync(It.Is<Url>(i => i.Href.Contains(urlPage1.Href))))
                        .ReturnsAsync(stream2);

                const string page2Name = "ReKreator.HtmlParser.Tests.TestPages.ConcertCategory.Page2.html";
                var stream3 = assembly.GetManifestResourceStream(page2Name);
                htmlProvider.Setup(p => p.GetHtmlPageAsync(It.Is<Url>(i => i.Href.Contains(urlPage2.Href))))
                        .ReturnsAsync(stream3);

                const string page3Name = "ReKreator.HtmlParser.Tests.TestPages.ConcertCategory.Page3.html";
                var stream4 = assembly.GetManifestResourceStream(page3Name);
                    htmlProvider.Setup(p => p.GetHtmlPageAsync(It.Is<Url>(i => i.Href.Contains(urlPage3.Href))))
                        .ReturnsAsync(stream4);

                // act
                var result = await provider.GetContentAsync();
                // assert
                var eventsCount = result.Count();
                eventsCount.Should().BeGreaterOrEqualTo(3);

                stream2?.Dispose();
                stream3?.Dispose();
                stream4?.Dispose();
            }
        }
    }
}
