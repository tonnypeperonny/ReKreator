using NUnit.Framework;
using ReKreator.Web.Controllers;

namespace ReKreator.Web.Tests
{
    internal class HomeControllerTests
    {
        [Test]
        public void HomeControllerTest_WhenReturnView()
        {
            // Arrange
            var controller = new HomeController();
            // Act
            var result = controller.Index();
            // Assert
            Assert.AreEqual("HomeController - Test", result);
        }
    }
}
