using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Controllers;
using ReKreator.Web.Models;

namespace ReKreator.Web.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
        private Mock<ISignUpOperation> signUpMock;
        private AccountController underTest;

        [SetUp]
        public void SetUp()
        {
            signUpMock = new Mock<ISignUpOperation>(); 
            underTest = new AccountController(signUpMock.Object);
        }

        [Test]
        public void SignUp_verify_SignUpOperations_method_was_called()
        {
            //arrange
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(new IdentityResult());

            //act
            underTest.SignUp(new SignUpModel());

            //assert
            signUpMock.Verify(a=>a.SignUp(It.IsAny<SignUpModel>()));
        }

        [Test]
        public void SignUp_should_return_correct_redirect_if_result_is_succeed()
        {
            //arrange
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(IdentityResult.Success);

            //act
            var view = underTest.SignUp(new SignUpModel()) as RedirectToRouteResult;

            //assert
            view.RouteValues["action"].Should().BeEquivalentTo("Index");
        }

        [Test]
        public void SignUp_should_return_signUp_view_if_identityResult_have_errors()
        {
            //arrange
            var errorList = new List<string> {"error1", "error2"};
            signUpMock.Setup(a => a.SignUp(It.IsAny<SignUpModel>())).Returns(new IdentityResult(errorList));

            //act
            var view = underTest.SignUp(new SignUpModel()) as ViewResult;
            var errors = view.ViewData.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            
            //assert
            view.ViewName.Should().BeEquivalentTo("SignUp");
            errors.Should().BeEquivalentTo(errorList);
        }
    }
}
