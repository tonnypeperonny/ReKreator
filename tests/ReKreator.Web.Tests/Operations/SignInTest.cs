using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Moq;
using NUnit.Framework;
using ReKreator.Common.Operations;
using ReKreator.Data.Models;
using ReKreator.Web.Authorization.SignIn;
using ReKreator.Web.Models;

namespace ReKreator.Web.Tests.Operations
{
    [TestFixture]
    public class SignInTest
    {
        private Mock<IUserStore<User>> userStoreMock;
        private Mock<UserManager<User>> userManagerMock;
        private Mock<IAuthenticationManager> authManager;
        private Mock<CookieAuthenticationOptions> cookieMock;
        private SignInOperation underTest;

        [SetUp]
        public void SetUp()
        {
            userStoreMock = new Mock<IUserStore<User>>();
            userManagerMock = new Mock<UserManager<User>>(userStoreMock.Object);
            authManager = new Mock<IAuthenticationManager>();
            cookieMock = new Mock<CookieAuthenticationOptions>();
            underTest = new SignInOperation(userManagerMock.Object, authManager.Object, cookieMock.Object);

            userManagerMock.Setup(a => a.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new User { UserName = "jora" });
            authManager.Setup(a =>
                a.SignIn(new AuthenticationProperties { IsPersistent = true }, It.IsAny<ClaimsIdentity>()));
            userManagerMock.Setup(a => a.CreateIdentityAsync(new User(), DefaultAuthenticationTypes.ApplicationCookie)).ReturnsAsync(new ClaimsIdentity());
            authManager.Setup(a => a.SignOut());
        }

        [Test]
        public async Task SignIn_are_signOut_findByName_checkPassword_were_called()
        {
            //arrange 
            userManagerMock.Setup(a => a.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);

            //act
            await underTest.SignInAsync(new SignInModel { Login = "jora", Password = It.IsAny<string>() });

            //verify
            userManagerMock.Verify(a => a.FindByNameAsync(It.IsAny<string>()));
            userManagerMock.Verify(a => a.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()));
            authManager.Verify(a => a.SignOut());
        }

        [Test]
        public async Task SignIn_should_fail_and_return_correct_operationResult()
        {
            //act
            var result = await underTest.SignInAsync(new SignInModel { Login = "jora", Password = It.IsAny<string>() });

            //verify
            result.Should().BeEquivalentTo(OperationResult.Fail(Resources.Resources.SignInError));
        }
    }
}
