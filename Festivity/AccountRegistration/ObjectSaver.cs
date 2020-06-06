namespace Festivity.AccountRegistration
{
    internal class ObjectSaver
    {
        public static void Save(UserModel user)
        {
            JSONUserList users = JSONFunctionality.GetUserList();
            users.Users.Add(user);
            JSONFunctionality.WriteToUserList(users);
            UserLoginPage.AutomaticLogin(user);
        }
    }
}