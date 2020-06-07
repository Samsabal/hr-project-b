namespace Festivity.AccountPage
{
    internal class PageBuilder
    {
        public static void ChangeInfo(int userSelection)
        {
            ConsoleHelperFunctions.ClearCurrentConsole();
            switch (userSelection)
            {
                case 1:
                    do { LoggedInAccount.User.FirstName = Utils.InputLoop("Input new firstname: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.FirstName));
                    break;

                case 2:
                    do { LoggedInAccount.User.LastName = Utils.InputLoop("Input new lastname: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.LastName));
                    break;

                case 3:
                    do { LoggedInAccount.User.Email = Utils.InputLoop("Input new email: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.Email));
                    break;

                case 4:
                    do { LoggedInAccount.User.userAddress.StreetName = Utils.InputLoop("Input new streetname: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.userAddress.StreetName));

                    do { LoggedInAccount.User.userAddress.StreetNumber = Utils.InputLoop("Input new streetnumber: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.userAddress.StreetNumber));
                    break;

                case 5:
                    do { LoggedInAccount.User.userAddress.City = Utils.InputLoop("Input new city: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.userAddress.City));
                    break;

                case 6:
                    do { LoggedInAccount.User.userAddress.ZipCode = Utils.InputLoop("Input new zipcode: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.userAddress.ZipCode));
                    break;

                case 7:
                    do { LoggedInAccount.User.userAddress.Country = Utils.InputLoop("Input new country: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.userAddress.Country));
                    break;

                case 8:
                    if (LoggedInAccount.User.AccountType == 1) // Organisator
                    {
                        do { LoggedInAccount.User.CompanyName = Utils.InputLoop("Input new company name: "); }
                        while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.CompanyName));
                        break;
                    }
                    if (LoggedInAccount.User.AccountType == 2) // Visitor
                    {
                        do { LoggedInAccount.User.PhoneNumber = Utils.InputLoop("Input new phone number: "); }
                        while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.PhoneNumber));
                        break;
                    }
                    break;

                case 9:
                    do { LoggedInAccount.User.CompanyPhoneNumber = Utils.InputLoop("Input new company phone number: "); }
                    while (!RegexUtils.IsValidAddressName(LoggedInAccount.User.CompanyPhoneNumber));
                    break;
            }
            LoggedInAccount.UpdateDatabase();
        }
    }
}