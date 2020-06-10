namespace Festivity.AccountRegistration
{
    internal class ObjectSaver
    {
        public static void Save(UserModel user)
        {
            JSONUserList users = JSONFunctions.GetUserList();
            users.Users.Add(user);
            JSONFunctions.WriteToUserList(users);
            Menu.OptionReset();
            AccountLogin.LoginHandler.InitiateAutomaticLogin(user);
        }
    }
}