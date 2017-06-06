using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency2
{
    public class TourSchedule : ITourSchedule
    {
        public List<Tour> Schedule { get; set; }
        public TourSchedule()
        {
            Schedule = new List<Tour>();
        }



        public void CreateTour(string nameoftour, DateTime dateTime, int numberofseats)
        {
            var result = Schedule.Count(x => x.Date.Date == dateTime.Date);

            if (result >= 3)
            {
                throw new TourAllocationException();
            }
           
            Schedule.Add(new Tour { Name = nameoftour, Date = dateTime.Date, NumberOfSeats = numberofseats });
        }

        public List<Tour> GetToursFor(DateTime timeTour)
        {
            return Schedule.Where(x => x.Date.Date == timeTour.Date).ToList();
        }
    }
}
