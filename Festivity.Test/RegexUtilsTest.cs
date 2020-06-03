using NUnit.Framework;
using System;
using Festivity;

namespace Festivity.Test
{
    [TestFixture]
    public class RegexUtilsTest
    {
        [Test]
        public void IsValidName_ShouldValidateNormalNames()
        {
            // Arrange
            bool expected = true;

            // Act
            bool actual = RegexUtils.IsValidName("12");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
