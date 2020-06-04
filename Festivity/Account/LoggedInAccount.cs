using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class LoggedInAccount
    {
        //private static readonly JSONUserList userList = JSONFunctionality.GetUserList();
        public static UserModel User;
        
        public static void SetUser(int accountID)
        {
            JSONUserList userList = JSONFunctionality.GetUserList();
            foreach (var user in userList.Users)
            {
                if (accountID == user.AccountID)
                {
                    User = user;
                }
            }
        }

        public static void LogOut()
        {
            User = null;
        }

        public static bool IsLoggedIn()
        {
            return User != null && User.AccountID > 0;
        }

        public static int GetID()
        {
            return User.AccountID;
        }

        public static void UpdateDatabase()
        {
            JSONUserList userList = JSONFunctionality.GetUserList();
            for (int i = 0; i < userList.Users.Count; i++)
            {
                if (GetID() == userList.Users[i].AccountID)
                {
                    userList.Users[i] = User;
                }
            }
            JSONFunctionality.WriteToUserList(userList);
        }
    }
}
