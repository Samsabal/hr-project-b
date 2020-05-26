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
    }
}