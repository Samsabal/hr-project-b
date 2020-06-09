namespace Festivity
{
    /// <summary> Class keeping track of the currently logged in user account. </summary>
    internal class LoggedInAccount
    {
        public static UserModel User;

        /// <summary>
        /// This function takes a accountID and sets the corresponding user as the logged in account.
        /// </summary>
        /// <param name="accountID"> AccountID to set the current user as. </param>
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

        /// <summary> Sets the currently logged in user to null </summary>
        public static void LogOut()
        {
            User = null;
        }

        /// <summary> Checks if a user is logged in </summary>
        /// <returns> Returns true if a user is logged in. </returns>
        public static bool IsLoggedIn()
        {
            return User != null && User.AccountID > 0;
        }

        /// <summary> Gets ID of currently logged in user </summary>
        /// <returns> Current user accountID </returns>
        public static int GetID()
        {
            return User.AccountID;
        }

        /// <summary> Updates the current user in the database. </summary>
        public static void UpdateDatabase()
        {
            JSONUserList userList = JSONFunctionality.GetUserList();
            for (int i = 0; i < userList.Users.Count; i++)
            {
                if (GetID() == userList.Users[i].AccountID)
                {
                    userList.Users[i] = User;
                    break;
                }
            }
            JSONFunctionality.WriteToUserList(userList);
        }

        public static bool hasFestivals()
        {
            JSONFestivalList festivalList = JSONFunctionality.GetFestivals();

            foreach (FestivalModel f in festivalList.Festivals)
            {
                if (f.FestivalOrganiserID == User.AccountID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}