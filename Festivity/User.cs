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

        public UserAddress userAddress = new UserAddress();

        [JsonProperty("companyContactperson")]
        public string contactPerson { get; set; }

        [JsonProperty("companyPhoneNumber")]
        public string companyPhoneNumber { get; set; }

        [JsonProperty("companyName")]
        public string companyName { get; set; }

        [JsonProperty("birthDate")]
        public string birthDate { get; set; }

        [JsonProperty("newsLetter")]
        public bool newsLetter { get; set; }

        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set; }
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

        public UserAddress companyAddress = new UserAddress();

    }

    class UserVisitor : User // derived class (child)
    {
        [JsonProperty("birthDate")]
        public string birthDate { get; set;}

        [JsonProperty("newsLetter")]
        public bool newsLetter { get; set;}

        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set;}


        public UserAddress visitorAddress = new UserAddress();
    }


    class JSONUserList
    {
        [JsonProperty("users")]
        public List<User> users { get; set; } // Change this to change back to userOrganisator/Visitor
    }
}