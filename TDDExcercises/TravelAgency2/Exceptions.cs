using System;

namespace TravelAgency2
{
    public class BookingPersonOnNonexistentTourException : Exception { }
    public class TourAllocationException : Exception { }
    public class BookingPersonOnTourWhereNoSeatsLeftException : Exception { }
}
