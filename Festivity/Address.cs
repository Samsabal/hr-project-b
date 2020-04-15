using Newtonsoft.Json;

namespace Festivity
{

    // Address class for location functionality
    class Address
    {
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("zipCode")]
        public string zipCode { get; set; }
        [JsonProperty("streetName")]
        public string streetName { get; set; }
        [JsonProperty("streetNumber")]
        public string streetNumber { get; set; }

        // Converts the address object into a readable string
        public string to_string()
        {
            string result = streetName + " " + streetNumber + ", " + zipCode + " " + city + ", " + country;
            return result;
        }
    }
}
