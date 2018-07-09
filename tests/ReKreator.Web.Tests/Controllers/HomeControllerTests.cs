using FluentAssertions;
using NUnit.Framework;
using ReKreator.Web.Controllers;

namespace ReKreator.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void When_index_action_invoked_then_should_return_view()
        {
            // arrange
            var controller = new HomeController();
            // act
            var result = controller.Index();
            // assert
            result.Should().NotBeNull();
        }
    }
}
