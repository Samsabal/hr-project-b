using Newtonsoft.Json;

namespace Festivity
{

    // Address class for location functionality
    class Address
    {
        [JsonProperty("Country")]
        private string country;
        [JsonProperty("City")]
        private string city;
        [JsonProperty("ZipCode")]
        private string zipCode;
        [JsonProperty("StreetName")]
        private string streetName;
        [JsonProperty("StreetNumber")]
        private string streetNumber;

        // Constructor of Address class

        public Address(string country, string city, string zipCode, string streetName, string streetNumber)
        {
            this.country = country;
            this.city = city;
            this.zipCode = zipCode;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
        }

        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string StreetNumber { get => streetNumber; set => streetNumber = value; }

        // Converts the address object into a readable string
        public string to_string()
        {
            string result = streetName + " " + streetNumber + ", " + zipCode + " " + city + ", " + country;
            return result;
        }
    }
}
