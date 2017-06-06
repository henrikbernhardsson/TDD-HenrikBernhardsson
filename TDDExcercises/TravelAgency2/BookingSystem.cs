using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency2
{
    public class BookingSystem
    {
        private List<Booking> Bookings { get; } = new List<Booking>();
        private ITourSchedule tourSchedule;
        public BookingSystem(ITourSchedule iTourSchedule)
        {
            tourSchedule = iTourSchedule;
        }

        public void CreateBooking(string tourName, DateTime dateOfTour, int seats, Passenger stubPassenger)
        {
            var tour = tourSchedule.Schedule.FirstOrDefault(x => x.Name == tourName);

            if (tour == null)
            {
                throw new BookingPersonOnNonexistentTourException();
            }
            if (tour.NumberOfSeats < seats)
            {
                throw new BookingPersonOnTourWhereNoSeatsLeftException();
            }
            var booking = new Booking
            {
                TourName = tourName,
                DateOfTour = dateOfTour,
                Seats = seats,
                Passenger = stubPassenger
            };
            Bookings.Add(booking);
        }

        public List<Booking> GetBookingsFor(Passenger stubPassenger)
        {
            return Bookings.Where(x => x.Passenger.FirstName == stubPassenger.FirstName &&
                                       x.Passenger.LastName == stubPassenger.LastName).ToList();
        }
    }
}
