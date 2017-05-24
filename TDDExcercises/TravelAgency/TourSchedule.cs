using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        public List<Tour> Schedule { get; set; }
        public TourSchedule()
        {
            Schedule = new List<Tour>();
        }

        public List<Tour> GetToursFor(DateTime date)
        {
            var toursOnDate = Schedule.Where(x => x.Date.Date == date.Date).ToList();
            return toursOnDate;
        }

        public void CreateTour(Tour tour)
        {
            if (Schedule.Where(x => x.Date == tour.Date).ToList().Count >= 3)
            {
                throw new TourAllocationException();
            }
            Schedule.Add(tour);
        }
    }
}
