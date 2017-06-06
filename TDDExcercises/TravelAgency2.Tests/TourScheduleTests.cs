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
            _sut.CreateTour("Madagaskar boat trip", new DateTime(2017, 10, 22), 44);
            var result = _sut.GetToursFor(new DateTime(2017, 10, 22));

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Madagaskar boat trip", result[0].Name);
            Assert.AreEqual(44, result[0].NumberOfSeats);

        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            _sut.CreateTour("Madagaskar boat trip", new DateTime(2017, 10, 22), 44);
            var result = _sut.GetToursFor(new DateTime(2017, 10, 22));

            Assert.AreEqual(new DateTime(2017, 10, 22), result[0].Date.Date);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            _sut.CreateTour("Madagaskar boat trip", new DateTime(2017, 10, 22), 44);
            _sut.CreateTour("New years day safari", new DateTime(2017, 01, 01), 44);
            _sut.CreateTour("Christmas Safari", new DateTime(2017, 12, 25), 44);

            var result = _sut.GetToursFor(new DateTime(2017, 01, 01));
           
            Assert.AreEqual(new DateTime(2017, 01, 01), result[0].Date.Date);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ThrowsExceptionWhenThereIsMoreThanOneTourPerDay()
        {
            _sut.CreateTour("Madagaskar boat trip", new DateTime(2017, 10, 22), 44);
            _sut.CreateTour("New years day safari", new DateTime(2017, 10, 22), 44);
            _sut.CreateTour("Christmas Safari", new DateTime(2017, 10, 22), 44);

            Assert.Throws<TourAllocationException>(() =>
            _sut.CreateTour("Boat trip to europe", new DateTime(2017, 10, 22), 44));
        }
    }
}

