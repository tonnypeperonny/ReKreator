using FluentAssertions;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using ReKreator.Data.Models;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Models;


namespace ReKreator.Web.Tests
{
    [TestFixture]
    public class SignUpTest
    {
        private Mock<IUserStore<ApplicationUser>> userStoreMock;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Mock<IAuthenticationManager> authManager;
        private SignUpOperation signinManager;

        [SetUp]
        public void SetUp()
        {
            userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object);
            authManager = new Mock<IAuthenticationManager>();
            signinManager = new SignUpOperation(userManagerMock.Object,  authManager.Object);
        }

        [Test]
        public void Registration_errorlist_should_be_null()
        {
            //act
            var list = signinManager.SignUp(new SignUpModel());

            //assert
            list.Should().Be(null);
        }
    }
}
