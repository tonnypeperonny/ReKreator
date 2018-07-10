using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReKreator.Web.Authorization.SignIn;
using ReKreator.Web.Authorization.SignOut;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Controllers;
using ReKreator.Web.Models;

namespace ReKreator.Web.Tests.Controllers
{
    [TestFixture]
    public class ErrorControllerTest
    {
        private Mock<HttpContextBase> httpContext;
        private Mock<HttpRequestBase> request;
        private Mock<HttpResponseBase> response;
        private ErrorController controller;
        private ControllerContext context;
        private static ErrorModel model; 

    [SetUp]
        public void SetUp()
        {
            httpContext = new Mock<HttpContextBase>();
            request = new Mock<HttpRequestBase>();
            response = new Mock<HttpResponseBase>();
            httpContext.Setup(x => x.Request).Returns(request.Object);
            httpContext.Setup(x => x.Response).Returns(response.Object);
            controller = new ErrorController();
            context = new ControllerContext(httpContext.Object,
                new RouteData(),
                controller);
            controller.ControllerContext = context;

            model = new ErrorModel {Message = "The server encountered an unexpected condition that prevented it from fulfilling the request.", ErrorTitle = "Internal server error"};
        }
        [Test]
        [TestCase(HttpStatusCode.InternalServerError)]
        public void When_index_action_invoked_then_should_return_view(HttpStatusCode id)
        {
            //act
            var result = controller.DisplayHttpError(id) as ViewResult;
            
            //assert
            result.Model.Should().BeEquivalentTo(model);
            result.ViewName.Should().BeEquivalentTo("DisplayHttpError");
        }

    }
}
