using System;

namespace TravelAgency2
{
    public class Booking
    {
        public Passenger Passenger { get; set; }
        public string TourName { get; set; }
        public int Seats { get; set; }
        public DateTime DateOfTour { get; set; }
    }
}
