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
        [TestCase("DogMan", true)]
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
        [Test]
        [TestCase("YES", true)]
        [TestCase("NO", true)]
        [TestCase("Yes", true)]
        [TestCase("nO", true)]
        [TestCase("sey", false)]
        [TestCase("-1", false)]
        [TestCase("yess", false)]
        public void IsValidYesOrNo_ShouldOnlyValidateYesOrNo(string input, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidYesOrNo(input));
        }

        [Test]
        [TestCase("Jananannanana", true)]
        [TestCase("10", false)]
        [TestCase("zxc zxc", true)]
        [TestCase("zxc zxc zxc", true)]
        public void IsValidAddressName_ShouldOnlyValidateNames(string input, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidAddressName(input));
        }

        [Test]
        [TestCase("12", false)]
        [TestCase("1111aa", true)]
        [TestCase("11111aa", false)]
        [TestCase("1111a", false)]
        [TestCase("", false)]
        public void IsValidZipCode_ShouldOnlyValidateDutchZipCodes(string input, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidZipCode(input));
        }

        [Test]
        [TestCase("", false)]
        [TestCase("12", true)]
        [TestCase("123", true)]
        [TestCase("1234", true)]
        [TestCase("12B", true)]
        [TestCase("12ba", true)]
        [TestCase("12b", true)]
        public void IsValidStreetNumber_ShouldOnlyValidateHouseNumbers(string input, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidStreetNumber(input));
        }

        [Test]
        [TestCase("0612345678", true)]
        [TestCase("06-12345678", true)]
        [TestCase("06 12345678", true)]
        [TestCase("(020) 123 34 54", true)]
        [TestCase("+31 06 12345678", true)]
        [TestCase("", false)]
        [TestCase("Pasd", false)]
        public void IsValidPhoneNumber_ShouldOnlyValidatePhoneNumbers(string input, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidPhoneNumber(input));
        }

        [Test]
        [TestCase("3,43", true)]
        [TestCase("3,432", false)]
        [TestCase("33,43", true)]
        [TestCase("333,43", true)]
        [TestCase("3", true)]
        [TestCase("45", true)]
        [TestCase("3,43", true)]

        public void IsValidPrice_ShouldOnlyValidatePriceFormat(string input, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidPrice(input));
        }

        [Test]
        [TestCase("12:29", true)]
        [TestCase("19:00", true)]
        [TestCase("21:59", true)]
        [TestCase("25:29", false)]
        [TestCase("03:29", true)]
        [TestCase("11", false)]
        [TestCase("1229", false)]
        [TestCase("", false)]
        public void IsValidTimeFormat_ShouldOnlyValidateTimeFormat(string input, bool expected)
        {
            Assert.AreEqual(expected, RegexUtils.IsValidTimeFormat(input));
        }
    }
}
