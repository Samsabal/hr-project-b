using NUnit.Framework;

namespace Festivity
{
    [TestFixture]
    public class SortingFunctionsTest
    {
        private static FestivalModel testFestival1 = new FestivalModel
        {
            FestivalID = 1,
            FestivalName = "A Test Festivall",
            FestivalDate = new DateTime(2021, 10, 15),
            FestivalStartingTime = new DateTime(2021, 10, 15, 10, 0, 0),
            FestivalEndTime = new DateTime(2021, 10, 15, 15, 0, 0),
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
            FestivalStatus = "",
            FestivalOrganiserID = 1
        };
        private static FestivalModel testFestival2 = new FestivalModel
        {
            FestivalID = 2,
            FestivalName = "B Test Festival",
            FestivalDate = new DateTime(2021, 10, 15),
            FestivalStartingTime = new DateTime(2021, 10, 15, 10, 0, 0),
            FestivalEndTime = new DateTime(2021, 10, 15, 15, 0, 0),
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
            FestivalStatus = "",
            FestivalOrganiserID = 1
        };
        private static FestivalModel testFestival3 = new FestivalModel
        {
            FestivalID = 3,
            FestivalName = "A Test Festival",
            FestivalDate = new DateTime(2021, 10, 15),
            FestivalStartingTime = new DateTime(2021, 10, 15, 10, 0, 0),
            FestivalEndTime = new DateTime(2021, 10, 15, 15, 0, 0),
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
            FestivalStatus = "",
            FestivalOrganiserID = 1
        };

        private static FestivalModel[] testArray1 = new FestivalModel[0] { };
        private static FestivalModel[] testArray2 = new FestivalModel[3] { testFestival1, testFestival2, testFestival3 };
        private static FestivalModel[] testArray3 = new FestivalModel[3] { testFestival1, testFestival3, testFestival2 };
        private static FestivalModel[] emptyTestArray = new FestivalModel[0] { };
        #region SortName

        [Test]
        [TestCase(testArray1, testArray2)]
        public void SortName_ShouldValidateNormalNames(FestivalModel[] testArray, FestivalModel[] expected)
        {
            // Arrange

            // Act
            FestivalModel[] actual = Utils.SortingFunctions.SortName(testArray);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}