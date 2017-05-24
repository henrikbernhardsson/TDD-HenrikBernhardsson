using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace TravelAgency.Tests
{
    [TestFixture]
    class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }

        [Test]
        public void CanCreateNewTour()
        {
            
            sut.CreateTour(new Tour("Madagaskar boat trip", new DateTime(2017, 10, 22), 44));
            var result = sut.GetToursFor(new DateTime(2017, 10, 22));

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            
            sut.CreateTour(new Tour("Madagaskar boat trip", new DateTime(2017, 10, 22, 12, 55, 32), 44));
            var result = sut.GetToursFor(new DateTime(2017, 10, 22));
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour(new Tour("Madagaskar boat trip", new DateTime(2017, 10, 22), 44));
            sut.CreateTour(new Tour("New years day safari", new DateTime(2017, 01, 01), 44));
            sut.CreateTour(new Tour("Christmas Safari", new DateTime(2017, 12, 25), 44));

            var result = sut.GetToursFor(new DateTime(2017, 01, 01));
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void NotMoreThanThreeToursADay()
        {
            sut.CreateTour(new Tour("Madagaskar boat trip", new DateTime(2017, 10, 22), 44));
            sut.CreateTour(new Tour("New years day safari", new DateTime(2017, 10, 22), 44));
            sut.CreateTour(new Tour("Christmas Safari", new DateTime(2017, 10, 22), 44));
            Assert.Throws<TourAllocationException>(() =>
            {
                sut.CreateTour(new Tour("Boat trip to europe", new DateTime(2017, 10, 22), 44));
            });
        }

    }
}
