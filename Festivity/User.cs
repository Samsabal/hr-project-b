using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class User // base class (parent)
    {
        [JsonProperty("accountType")]
        public int accountType { get; set; }

        [JsonProperty("accountID")]
        public int accountID { get; set; }
        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("companyContactperson")]
        public string contactPerson { get; set; }

        [JsonProperty("companyPhoneNumber")]
        public string companyPhoneNumber { get; set; }

        [JsonProperty("companyName")]
        public string companyName { get; set; }

        public Date birthDate = new Date();

        [JsonProperty("newsLetter")]
        public int newsLetter { get; set; }

        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set; }

        public Address userAddress = new Address();
    }

    class JSONUserList
    {
        [JsonProperty("users")]
        public List<User> users { get; set; } // Change this to change back to userOrganisator/Visitor
    }
}