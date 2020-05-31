using Newtonsoft.Json;

namespace Festivity
{

    // Address class for location functionality
    public class Address
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
        [JsonProperty("streetName")]
        public string StreetName { get; set; }
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }

        // Converts the address object into a readable string
        public override string ToString()
        {
            string result = StreetName + " " + StreetNumber + ", " + ZipCode + " " + City + ", " + Country;
            return result;
        } 
    }
}
