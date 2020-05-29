using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Festivity
{
    internal class JSONData
    {
        private static string PATH_USER = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
        public static JSONUserList userList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PATH_USER));

        public static void writeToUserDatabase(User user)
        {
            userList.users.Add(user);
            string json = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(PATH_USER, json);
        }

        public static int generateUserID()
        {
            int accountID;
            if (userList.users.Count == 0)
            {
                accountID = 1;
            }
            else
            {
                int item = userList.users[userList.users.Count - 1].accountID;
                accountID = item + 1;
            };
            return accountID;
        }
    }
}