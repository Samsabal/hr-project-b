using System.Collections.Generic;
using Newtonsoft.Json;

namespace Festivity
{
    class User // base class (parent)
    {
        [JsonProperty("firstName")]
        public string firstName { get; set; }
        [JsonProperty("lastName")]
        public string lastName { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("accountType")]
        public int accountType { get; set; }
        [JsonProperty("accountID")]
        public int accountID { get; set; }
    }

        class UserAddress // base class (parent)
    {   
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("streetName")]
        public string streetName { get; set; }
        [JsonProperty("streetNumber")]
        public string streetNumber { get; set; }
        [JsonProperty("zipCode")]
        public string zipCode { get; set; }
    }

    class UserAdmin : User // derived class (child)
    {
        
    }

    class UserOrganisator : User // derived class (child)
    {
        [JsonProperty("contactPerson")]
        public string contactPerson { get; set; }
        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set; }
        [JsonProperty("companyName")]
        public string companyName { get; set; }

        
        [JsonObject("companyAddress")]
        UserAddress companyAddress = new UserAddress();
        // Still figuring out how this will work
    }

    class UserVisitor : User // derived class (child)
    {
        [JsonProperty("birthDate")]
        public string birthDate { get; set;}

        [JsonObject("visitorAddress")]
        public string visitorAddress { get; set;}
        // Same deal as above

        [JsonProperty("newsLetter")]
        public bool newsLetter { get; set;}
        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set;}
    }


    class JSONUserList
    {
        [JsonProperty("users")]
        public List<User> users { get; set; }
    }
}