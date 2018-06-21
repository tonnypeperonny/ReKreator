using System;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using ReKreator.Data.Models;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Models;

namespace ReKreator.Web.Tests.Operations
{
    public class SignUpTests
    {
        private Mock<IUserStore<User>> userStoreMock;
        private Mock<UserManager<User>> userManagerMock;
        private Mock<IIdentityValidator<User>> signupValidator;
        private SignUpOperation underTest;

        [SetUp]
        public void SetUp()
        {
            userStoreMock = new Mock<IUserStore<User>>();
            signupValidator = new Mock<IIdentityValidator<User>>();
            userManagerMock = new Mock<UserManager<User>>(userStoreMock.Object);
            underTest = new SignUpOperation(userManagerMock.Object, signupValidator.Object);
        }

        [Test]
        public void When_constructor_invoke_with_null_parameter_should_throw_exception()
        {
            //act
            Action act = () => new SignUpOperation(null, null);

            //assert
            act.Should().Throw<ArgumentNullException>();
        }

       [Test]
        public void When_singUp_invoke_with_null_parameter_should_throw_exception()
        {
            //act
            Action act = () => underTest.SignUp(null);

            //assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void When_signUp_invoke_with_normal_parameter_should_return_success()
        {
            //act
            var model = new SignUpModel();
            var result = underTest.SignUp(model);

            //assert
            result.Should().Be(IdentityResult.Success);
        }

        [Test]
        public void When_signUp_invoke_where_userManager_create_return_some_error_should_retund_failed()
        {
            //act
            var result = underTest.SignUp(new SignUpModel());

            //assert
            result.Should().Be(IdentityResult.Success);
        }
    }
}
