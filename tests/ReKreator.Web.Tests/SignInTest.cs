using System;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ReKreator.Data.Models;
using ReKreator.Web.Authorization.SignIn;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Models;

namespace ReKreator.Web.Tests
{
    [TestFixture]
    public class SignInTest
    {
        private Mock<IUserStore<ApplicationUser>> userStoreMock;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Mock<IAuthenticationManager> authManager;
        private SignInOperation signinManager;

        [SetUp]
        public void SetUp()
        {
            userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object);
            authManager = new Mock<IAuthenticationManager>();
            signinManager = new SignInOperation(userManagerMock.Object, authManager.Object);
        }

        [Test]
        public void SignIn_Is_AuthManager_was_called()
        {
            //arrange 
            
            authManager.Setup(a =>
                a.SignIn(new AuthenticationProperties {IsPersistent = true}, It.IsAny<ClaimsIdentity>()));
            authManager.Setup(a =>a.SignOut());

            //act
            signinManager.SignIn(new SignInModel());

            //verify
            authManager.Setup(a =>
                a.SignIn(new AuthenticationProperties { IsPersistent = true }, It.IsAny<ClaimsIdentity>()));
            authManager.Setup(a => a.SignOut());
        }
    }
}
