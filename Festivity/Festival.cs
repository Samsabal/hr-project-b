using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{

    // Temporary Festival class for testing purposes
    class Festival
    {

        // Fields for variables

        private string name;
        public string description;
        public Date date;
        public int minimumAge;
        public Address festivalLocation;
        public string ticketInfo;
        public int festivalID;

        public string Name { get => name; set => name = value; }


        // Constructor for Festival class
        public Festival(string name, string description, Date date, int minimumAge, Address festivalLocation, string ticketInfo, int festivalID)
        {
            this.name = name;
            this.description = description;
            this.date = date;
            this.minimumAge = minimumAge;
            this.festivalLocation = festivalLocation;
            this.ticketInfo = ticketInfo;
            this.festivalID = festivalID;
        }
    }
}