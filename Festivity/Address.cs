using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{

    // Address class for location functionality
    class Address
    {
        private string country;
        private string city;
        private string zipCode;
        private string streetName;
        private string streetNumber;

        // Constructor of Address class

        public Address(string country, string city, string zipCode, string street, string streetNumber)
        {
            this.country = country;
            this.city = city;
            this.zipCode = zipCode;
            this.streetName = street;
            this.streetNumber = streetNumber;
        }

        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string StreetNumber { get => streetNumber; set => streetNumber = value; }

        // Checks if two addresses are the same

        public bool is_equal(Address other)
        {
            if (this.country == other.country && this.city == other.city && this.zipCode == other.zipCode
                && this.streetName == other.streetName && this.streetNumber == other.streetNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Converts the address object into a readable string
        public string to_string()
        {
            string result = streetName + " " + streetNumber + ", " + zipCode + " " + city + ", " + country;
            return result;
        }
    }
}
