namespace Festivity.AccountPage
{
    internal class Manager
    {
        public static void DrawPage()
        {
            Writer.AccountPage();
        }

        public static void InitateInfoChange()
        {
            Menu.OptionReset();
            UserRegisterHandler.ShowUserRegister(LoggedInAccount.User, false);
        }
    }
}