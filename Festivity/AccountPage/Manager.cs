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
            Writer.ChangeInfoPage();
            PageBuilder.ChangeInfo(Reader.AccountOption());
        }
    }
}