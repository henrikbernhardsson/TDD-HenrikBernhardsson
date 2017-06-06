using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TravelAgency2.Tests
{
    [TestFixture]
    [Category("TravelAgency2 BookinSystemTests")]
    public class BookingSystemTests
    {
        private BookingSystem _sut;
        private TourScheduleStub TourScheduleStub { get; set; }
        private Passenger _stubPassenger;


        [SetUp]
        public void Setup()
        {
            TourScheduleStub = new TourScheduleStub();
            _sut = new BookingSystem(TourScheduleStub);
            _stubPassenger = new Passenger()
            {
                FirstName = "John",
                LastName = "Doe"
            };
        }

        [Test]
        public void CanCreateBooking()
        {
            TourScheduleStub.Schedule = new List<Tour>
            {
                new Tour
                {
                    Name = "Boat Tour",
                    Date = new DateTime(2017, 12, 1),
                    NumberOfSeats = 10
                }
            };

            _sut.CreateBooking("Boat Tour", new DateTime(2017, 12, 1), 10, _stubPassenger);

            List<Booking> bookingsList = _sut.GetBookingsFor(_stubPassenger);

            var model = bookingsList[0];

            Assert.AreEqual(1, bookingsList.Count);
            Assert.AreEqual("Boat Tour", model.TourName);
            Assert.AreEqual(_stubPassenger, model.Passenger);
            Assert.AreEqual(TourScheduleStub.Schedule[0].Name, model.TourName);

        }

        [Test]
        public void BookingAPassengerOnANonExistentTourThrowsException()
        {
            TourScheduleStub.Schedule = new List<Tour>();

            Assert.Throws<BookingPersonOnNonexistentTourException>(() =>
                _sut.CreateBooking("Boat Tour", new DateTime(2017, 12, 1), 10, _stubPassenger));
        }

        [Test]
        public void BookingAPassengerOnTourWithNoSeatsLeftThrowsException()
        {
            TourScheduleStub.Schedule = new List<Tour>
            {
                new Tour
                {
                    Name = "Boat Tour",
                    Date = new DateTime(2017, 12, 1),
                    NumberOfSeats = 10
                }
            };

            Assert.Throws<BookingPersonOnTourWhereNoSeatsLeftException>(() =>
                _sut.CreateBooking("Boat Tour", new DateTime(2017, 12, 1), 12, _stubPassenger));
        }
    }
}
