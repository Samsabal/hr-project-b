using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity
{
    class Date
    {
        private int day;
        private int month;
        private int year;

        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        
        public string to_string()
        {
            string result = day + "/" + month + "/" + year;
            return result;
        }

        public Boolean isEqual(Date other)
        {
            if (this.day == other.day && this.month == other.month && this.year == other.year)
            {
                return true;
            }
            else return false;
        }
    }
}
