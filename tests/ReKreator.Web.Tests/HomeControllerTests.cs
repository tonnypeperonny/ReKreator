using FluentAssertions;
using NUnit.Framework;
using ReKreator.Web.Controllers;

namespace ReKreator.Web.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void When_Index_Action_Invoked_Then_Should_Return_View()
        {
            var controller = new HomeController();

            var result = controller.Index();

            result.Should().NotBeNull();
        }
    }
}
