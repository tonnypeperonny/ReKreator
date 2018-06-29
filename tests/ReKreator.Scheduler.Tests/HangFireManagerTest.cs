using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Common;
using Hangfire.States;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ReKreator.Scheduler.Tests
{
    [TestFixture]
    public class HangFireManagerTest
    {
        private Mock<IBackgroundJobClient> jobMock;
        private HangFireManager hangfireManager;

        [SetUp]
        public void SetUp()
        {
            jobMock = new Mock<IBackgroundJobClient>();
            hangfireManager = new HangFireManager();
        }

        [Test]
        public void When_constructor_invoe_with_null_parameter_should_throw_exception()
        {
            var act = new Action(() => Console.WriteLine(""));
            //act
            hangfireManager.DailyParsing(act);

            //assert
            jobMock.Verify(a=>a.Create(It.Is<Job>(job => job.Method.Name == It.IsAny<string>()),
                It.IsAny<EnqueuedState>()));
        }
    }
}
