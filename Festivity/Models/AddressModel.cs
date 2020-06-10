using Newtonsoft.Json;

namespace Festivity
{
    /// <summary> Address class used for location functionality </summary>
    public class AddressModel
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

        public override string ToString()
        {
            return $"{StreetName} {StreetNumber}, {ZipCode} {City}, {Country}";
        }
    }
}