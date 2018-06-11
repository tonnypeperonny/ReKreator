using System;

using FluentAssertions;

using NUnit.Framework;

namespace ReKreator.Utils.Tests
{
    [TestFixture]
    public sealed class PreconditionTests
    {
        [Test]
        public void CheckNotNull_WhenTheNulLValueIsPassed_ShouldThrowException()
        {
            // arrange
            string value = null;
            
            // act
            Action act = () => Preconditions.CheckNotNull(value, nameof(value));
            
            // assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
