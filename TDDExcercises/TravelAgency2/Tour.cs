using System;

namespace TravelAgency2
{
    public class Tour
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfSeats { get; set; }

        public Tour()
        {

        }

        public Tour(string tourname, DateTime tourdate, int numberofseats)
        {
            Name = tourname;
            Date = tourdate;
            NumberOfSeats = numberofseats;
        }
    }
}
