using System;

namespace Festivity
{
    class FestivalRegister
    {
        public static void festival_register()
        {
            Console.WriteLine("You will now start the festival registering fase");
            Console.WriteLine("Fill in the name of the festival: ");
            string festivalName = Console.ReadLine();
            Console.WriteLine("Fill in the festival date(dd:mm:yyyy): ");
            string festivalDate = Console.ReadLine();
            Console.WriteLine("Fill in starting time(hh:mm): ");
            string fesitvalStartingTime = Console.ReadLine();
            Console.WriteLine("Fill in the expected end time(hh:mm): ");
            string festivalEndTime = Console.ReadLine();
            Console.WriteLine("Fill in the adress of the location.");
            Console.WriteLine("Fill in the country: ");
            string festivalLocationCountry = Console.ReadLine();
            Console.WriteLine("Fill in the city: ");
            string festivalLocationCity = Console.ReadLine();
            Console.WriteLine("Fill in the street: ");
            string festivalLocationStreet = Console.ReadLine();
            Console.WriteLine("Fill in the house number: ");
            string festivalLocationHouseNumber = Console.ReadLine();
            Console.WriteLine("Fill in the festival description (press enter when finished but don't press enter for a new line): ");
            string festivalDescription = Console.ReadLine();
            Console.WriteLine("Fill in the age restriction as a number");
            string festivalAgeRestriction = Console.ReadLine();
            Console.WriteLine("Fill in the genre of the festival: ");
            string festivalGenre = Console.ReadLine();
            Console.WriteLine("Fill in the amount of various tickets as anumber: ");
            int festivalAmountVariousTickets = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < festivalAmountVariousTickets; i++)
            {
                Console.WriteLine("Fill in the ticket name of ticket ", (i + 1),
                ": ");
                string festivalTicketName = Console.ReadLine();
                Console.WriteLine("Fill in ticket description");
                string festivalTicketDescription = Console.ReadLine();
                Console.WriteLine("Fill in the price of the ticket in euros: ");
                string festivalticketPrice = Console.ReadLine();
            }
        }
    }
}
