using System;
using NUnit.Framework;

namespace TravelAgency2.Tests
{

    [TestFixture]
    [Category("TravelAgency2 TourScheduleTests")]
    public class TourScheduleTests
    {
        private TourSchedule _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new TourSchedule();
        }
        [Test]
        public void CanCreateNewTour()
        {
            _sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);
            var result = _sut.GetToursFor(new DateTime(2013, 1, 1));

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("New years day safari", result[0].Name);
            Assert.AreEqual(20, result[0].NumberOfSeats);

        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            _sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            var result = _sut.GetToursFor(new DateTime(2013, 1, 1));

            Assert.AreEqual(new DateTime(2013, 1, 1), result[0].Date.Date);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            _sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            _sut.CreateTour("May safari", new DateTime(2013, 5, 1, 10, 15, 0), 20);
            _sut.CreateTour("July safari", new DateTime(2013, 7, 1, 10, 15, 0), 20);
            _sut.CreateTour("April safari", new DateTime(2013, 4, 1, 10, 15, 0), 20);

            var result = _sut.GetToursFor(new DateTime(2013, 4, 1));

            Assert.AreEqual(new DateTime(2013, 4, 1), result[0].Date.Date);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ThrowsExceptionWhenThereIsMoreThanOneTourPerDay()
        {
            _sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            _sut.CreateTour("January safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            _sut.CreateTour("Winter safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);

            Assert.Throws<TourAllocationException>(() => _sut.CreateTour("Winter safari", new DateTime(2013, 1, 1, 10, 15, 0), 20));
        }
    }
}

