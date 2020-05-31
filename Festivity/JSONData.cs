using Newtonsoft.Json;
using System.IO;

namespace Festivity
{
    internal class JSONData
    {
        private static readonly string PathUser = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..", @"UsersDatabase.json");
        public static JSONUserList userList = JsonConvert.DeserializeObject<JSONUserList>(File.ReadAllText(PathUser));

        public static void WriteToUserDatabase(User user)
        {
            userList.Users.Add(user);
            string json = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(PathUser, json);
        }

        public static int GenerateUserID()
        {
            int accountID;
            if (userList.Users.Count == 0)
            {
                accountID = 1;
            }
            else
            {
                int item = userList.Users[userList.Users.Count - 1].AccountID;
                accountID = item + 1;
            };
            return accountID;
        }
    }
}