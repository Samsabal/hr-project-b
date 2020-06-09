using NUnit.Framework;
using System;

namespace Festivity.Test
{
    [TestFixture]
    public class FestivalModelTest
    {
        #region IsRefundable

        [Test]
        [TestCase(8, 1, true)]
        [TestCase(6, 1, false)]
        [TestCase(50, 5, true)]
        public void IsRefundable_ShouldCalculateRefundable(int testDaysFromNow, int testCancelTime, bool expected)
        {
            // Arrange
            FestivalModel testFestival1 = new FestivalModel
            {
                FestivalID = 1,
                FestivalName = "A Test Festivall",
                FestivalDate = DateTime.Now.AddDays(testDaysFromNow),
                FestivalStartingTime = DateTime.Now.AddDays(testDaysFromNow),
                FestivalEndTime = DateTime.Now.AddDays(testDaysFromNow),
                FestivalLocation = new Address
                {
                    Country = "",
                    City = "",
                    ZipCode = "",
                    StreetName = "",
                    StreetNumber = ""
                },
                FestivalDescription = "",
                FestivalAgeRestriction = 0,
                FestivalGenre = "",
                FestivalCancelTime = testCancelTime,
                FestivalStatus = "",
                FestivalOrganiserID = 1
            };

            // Act
            bool actual = testFestival1.IsRefundable();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region CheckStatusTicketTable
        [Test]
        [TestCase(2020, 07, 12, null, "This festival is upcoming")]
        [TestCase(2020, 05, 12, null, "This festival has ended")]
        [TestCase(2020, 07, 12, "Changed", "Changed")]
        [TestCase(2020, 05, 12, "Changed", "Changed")]
        public void CheckStatusTicketTable_ShouldGetStatus(int testYear, int testMonth, int testDay, string testStatus, string expected)
        {
            // Arrange
            FestivalModel testFestival1 = new FestivalModel
            {
                FestivalID = 1,
                FestivalName = "A Test Festival",
                FestivalDate = new DateTime(testYear, testMonth, testDay),
                FestivalStartingTime = new DateTime(testYear, testMonth, testDay, 0, 0, 1),
                FestivalEndTime = new DateTime(testYear, testMonth, testDay, 23, 59, 59),
                FestivalLocation = new Address
                {
                    Country = "",
                    City = "",
                    ZipCode = "",
                    StreetName = "",
                    StreetNumber = ""
                },
                FestivalDescription = "",
                FestivalAgeRestriction = 0,
                FestivalGenre = "",
                FestivalCancelTime = 0,
                FestivalStatus = testStatus,
                FestivalOrganiserID = 1
            };

            // Act
            string actual = testFestival1.CheckStatusTicketTable();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, "This festival is ongoing")]
        [TestCase("Changed", "Changed")]
        public void CheckStatusTicketTable_ShouldGetStatusOngoing(string testStatus, string expected)
        {
            // Arrange
            FestivalModel testFestival1 = new FestivalModel
            {
                FestivalID = 1,
                FestivalName = "A Test Festival",
                FestivalDate = DateTime.Now,
                FestivalStartingTime = DateTime.Now.AddHours(-1),
                FestivalEndTime = DateTime.Now.AddHours(1),
                FestivalLocation = new Address
                {
                    Country = "",
                    City = "",
                    ZipCode = "",
                    StreetName = "",
                    StreetNumber = ""
                },
                FestivalDescription = "",
                FestivalAgeRestriction = 0,
                FestivalGenre = "",
                FestivalCancelTime = 0,
                FestivalStatus = testStatus,
                FestivalOrganiserID = 1
            };

            // Act
            string actual = testFestival1.CheckStatusTicketTable();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region 
        [Test]
        [TestCase("testtesttesttesttesttest", "testtes...")]
        [TestCase("test", "test      ")]
        public void SetDescriptionLength_ShouldSetLength(string testDescription, string expected)
        {
            // Arrange
            FestivalModel testFestival1 = new FestivalModel
            {
                FestivalID = 1,
                FestivalName = "A Test Festival",
                FestivalDate = DateTime.Now,
                FestivalStartingTime = DateTime.Now,
                FestivalEndTime = DateTime.Now,
                FestivalLocation = new Address
                {
                    Country = "",
                    City = "",
                    ZipCode = "",
                    StreetName = "",
                    StreetNumber = ""
                },
                FestivalDescription = testDescription,
                FestivalAgeRestriction = 0,
                FestivalGenre = "",
                FestivalCancelTime = 0,
                FestivalStatus = null,
                FestivalOrganiserID = 1
            };

            // Act
            string actual = testFestival1.SetDescriptionLength(10);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

    }
}
