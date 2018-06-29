using System.Security.Claims;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using ReKreator.Web.Authorization.SignIn;
using ReKreator.Web.Authorization.SignOut;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Controllers;
using ReKreator.Web.Models;


namespace ReKreator.Web.Tests
{
    [TestFixture]
    public class AccountControllerTest
    {
        private Mock<ISignInOperation> signInMock;
        private Mock<ISignOutOperation> signOutMock;
        private Mock<ISignUpOperation> signUpMock;
        private AccountController accountController;

        [SetUp]
        public void SetUp()
        {
            signInMock = new Mock<ISignInOperation>();
            signUpMock = new Mock<ISignUpOperation>();
            signOutMock = new Mock<ISignOutOperation>();
            accountController = new AccountController(signInMock.Object,signOutMock.Object,signUpMock.Object);
        }

        [Test]
        public void Regiser_verify_SignInOperations_method_was_called()
        {
            //arrange
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(new IdentityResult());

            //act
            accountController.SignUp(new SignUpModel());

            //assert
            signUpMock.Verify(a=>a.SignUp(It.IsAny<SignUpModel>()));
        }

        [Test]
        public void Register_should_return_correct_view_with_modelErrors()
        {
            //arrange
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(new IdentityResult());

            //act
            var view = accountController.SignUp(new SignUpModel()) as RedirectToRouteResult;

            // Assert
            view.RouteValues["action"].Should().BeEquivalentTo("Index");
        }

        [Test]
        public void Login_verify_SignInOperations_method_was_called()
        {
            //arrange
            signInMock.Setup(a => a.SignIn(It.IsAny<SignInModel>())).Returns(new ClaimsIdentity());

            //act
            accountController.SignIn(new SignInModel());

            //assert
            signInMock.Verify(a => a.SignIn(It.IsAny<SignInModel>()));
        }

        [Test]
        public void Login_should_return_correctView_if_SignIn_returns_null()
        {
            //arrange
            signInMock.Setup(a => a.SignIn(It.IsAny<SignInModel>())).Returns((ClaimsIdentity)null);

            //act
            var result = accountController.SignIn(new SignInModel()) as ViewResult;

            //assert
            result.ViewName.Should().BeEquivalentTo("SignIn");
        }

        [Test]
        public void Logout_verify_SignOutOperation_was_called()
        {
            //arrange
            signOutMock.Setup(a => a.Logout());

            //act
            accountController.Logout();

            //assert
            signOutMock.Verify(a => a.Logout());
        }
    }
}
