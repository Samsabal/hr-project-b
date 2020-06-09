using NUnit.Framework;

namespace Festivity.Test
{
    [TestFixture]
    public class RegexUtilsTest
    {
        #region IsValidName
        [Test]
        [TestCase("Robin", true)]
        [TestCase("Babe is big", true)]
        [TestCase("12343", false)]
        [TestCase("", false)]
        [TestCase("Dog-Man", true)]
        public void IsValidName_ShouldValidateNormalNames(string name, bool expected)
        {
            // Arrange

            // Act
            bool actual = RegexUtils.IsValidName(name);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region IsValidIban
        [Test]
        [TestCase("NL12RABO1234567890", true)]
        [TestCase("NL12RABO123456789", false)]
        [TestCase("JK12RABO1234567891", false)]
        [TestCase("dd", false)]
        [TestCase("123123123123123123", false)]
        [TestCase("JKOORABO1234K67891", false)]
        public void IsValidIban_ShouldValidateOnlyIBANNumbers(string IBAN, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidIBAN(IBAN));
        }
        #endregion

        #region IsValidUserDay
        [Test]
        [TestCase("5", true)]
        [TestCase("0", false)]
        [TestCase("00", false)]
        [TestCase("-1", false)]
        [TestCase("32", false)]
        [TestCase("03", true)]
        [TestCase("09", true)]
        [TestCase("201", false)]
        [TestCase("??", false)]
        public void IsValidUserDay_ShouldOnlyValidateDays(string day, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidDay(day));
        }
        #endregion
    }
}
