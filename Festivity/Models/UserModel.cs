using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class UserModel // base class (parent)
    {
        [JsonProperty("accountType")]
        public int AccountType { get; set; }

        [JsonProperty("accountID")]
        public int AccountID { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("companyContactperson")]
        public string ContactPerson { get; set; }

        [JsonProperty("companyPhoneNumber")]
        public string CompanyPhoneNumber { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("companyIBAN")]
        public string CompanyIBAN { get; set; }
        [JsonProperty("birthDate", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{4}-\d\d-\d\dT\d\d:\d\d:\d\d\.\d{3}Z$")]
        public DateTime BirthDate { get; set; }


        [JsonProperty("newsLetter")]
        public bool NewsLetter { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        public Address userAddress = new Address();
    }

    internal class JSONUserList
    {
        [JsonProperty("users")]
        public List<UserModel> Users { get; set; } // Change this to change back to userOrganisator/Visitor
    }
}