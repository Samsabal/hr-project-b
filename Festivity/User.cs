using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class User
    {
        [JsonProperty("firstName")]
        public int Id { get; set; }
        [JsonProperty("lastName")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Password { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("accountType")]
        public string accountType { get; set; }
        [JsonProperty("accountID")]
        public string accountID { get; set; }
    }

    class UserAdmin : User
    {

    }

    class UserOrganisator : User
    {
        [JsonProperty("contactPerson")]
        public int ContactPerson { get; set; }
        [JsonProperty("phoneNumber")]
        public int phoneNumber { get; set; }
        [JsonProperty("companyName")]
        public int companyName { get; set; }
        [JsonProperty("companyAddress")]
        public int phoneNumber { get; set; }
    }

    class UserVisitor : User
    {

    }

    class JSONUserList
    {
        [JsonProperty("users")]
        public List<User> users { get; set; }
    }
}