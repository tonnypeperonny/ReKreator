using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using ReKreator.Common.Operations;
using ReKreator.Web.Authorization.SignIn;
using ReKreator.Web.Authorization.SignOut;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Controllers;
using ReKreator.Web.Models;

namespace ReKreator.Web.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
        private Mock<ISignInOperation> signInMock;
        private Mock<ISignOutOperation> signOutMock;
        private Mock<ISignUpOperation> signUpMock;
        private AccountController underTest;

        [SetUp]
        public void SetUp()
        {
            signInMock = new Mock<ISignInOperation>();
            signUpMock = new Mock<ISignUpOperation>();
            signOutMock = new Mock<ISignOutOperation>();
            underTest = new AccountController(signUpMock.Object, signOutMock.Object, signInMock.Object);
        }

        [Test]
        public void SignUp_verify_SignUpOperations_method_was_called()
        {
            //arrange
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(new OperationResult<IdentityResult>{Content = new IdentityResult()});

            //act
            underTest.SignUp(new SignUpModel());

            //assert
            signUpMock.Verify(a => a.SignUp(It.IsAny<SignUpModel>()));
        }

        [Test]
        public void SignUp_should_return_correct_redirect_if_result_is_succeed()
        {
            //arrange
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(OperationResult.Succeed<IdentityResult>(IdentityResult.Success));

            //act
            var view = underTest.SignUp(new SignUpModel()) as RedirectToRouteResult;

            //assert
            view.RouteValues["action"].Should().BeEquivalentTo("SignIn");
        }

        [Test]
        public void SignUp_should_return_signUp_view_if_identityResult_have_errors()
        {
            //arrange
            var errorList = new List<string> { "error1", "error2" };
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(OperationResult.Fail(new IdentityResult(errorList),"error"));

            //act
            var view = underTest.SignUp(new SignUpModel()) as ViewResult;
            var errors = view.ViewData.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

            //assert
            view.ViewName.Should().BeEquivalentTo("SignUp");
            errors.Should().BeEquivalentTo(errorList);
        }
        

        [Test]
        public void SignOut_verify_signOutOperation_was_called()
        {
            //arrange
            signOutMock.Setup(a => a.SignOut());

            //act
            underTest.SignOut();

            //assert
            signOutMock.Verify(a => a.SignOut());
        }

        [Test]
        public void SignIn_verify_SignInOperations_method_was_called()
        {
            //arrange
            signInMock.Setup(a => a.SignInAsync(It.IsAny<SignInModel>())).ReturnsAsync(new OperationResult { Succedeed = false });

            //act
            underTest.SignIn(new SignInModel());

            //assert
            signInMock.Verify(a => a.SignInAsync(It.IsAny<SignInModel>()));
        }

        [Test]
        public  void Login_should_return_correctView_if_SignIn_returns_null()
        {
            //arrange
            signInMock.Setup(a => a.SignInAsync(It.IsAny<SignInModel>())).ReturnsAsync(new OperationResult { Succedeed = false });

            //act
            var result =  underTest.SignIn(new SignInModel()).Result as ViewResult;

            //assert
            result.ViewName.Should().BeEquivalentTo("SignIn");
        }

        [Test]
        public void SignIn_should_return_signIn_view_with_errors()
        {
            //arrange
            signInMock.Setup(a => a.SignInAsync(It.IsAny<SignInModel>())).ReturnsAsync(OperationResult.Fail(Resources.Resources.SignInError));

            //act
            var view = underTest.SignIn(new SignInModel()).Result as ViewResult;
            var errors = view.ViewData.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);

            //assert
            view.ViewName.Should().BeEquivalentTo("SignIn");
            errors.Should().BeEquivalentTo(Resources.Resources.SignInError);
        }
    }
}

