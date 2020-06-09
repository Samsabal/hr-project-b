namespace Festivity.AccountRegistration
{
    internal class ObjectSaver
    {
        public static void Save(UserModel user)
        {
            JSONUserList users = JSONFunctions.GetUserList();
            users.Users.Add(user);
            JSONFunctions.WriteToUserList(users);
            AccountLogin.LoginHandler.InitiateAutomaticLogin(user);
        }
    }
}