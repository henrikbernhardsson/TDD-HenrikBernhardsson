using System;
using System.Collections.Generic;

namespace TravelAgency2.Tests
{
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Schedule { get; set; }
        public List<DateTime> CallsToGetToursFor;


        public void CreateTour(string nameoftour, DateTime tourDateTime, int numberofseats)
        {

        }

        public List<Tour> GetToursFor(DateTime timeTour)
        {
            if (CallsToGetToursFor == null)
            {
                CallsToGetToursFor = new List<DateTime>();
            }
            CallsToGetToursFor.Add(timeTour);
            return Schedule;
        }
    }
}
