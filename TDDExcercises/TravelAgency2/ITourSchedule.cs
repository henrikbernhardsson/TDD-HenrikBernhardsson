using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency2
{
    public interface ITourSchedule
    {
        List<Tour> Schedule { get; set; }
        void CreateTour(string nameoftour, DateTime dateTime, int numberofseats);
        List<Tour> GetToursFor(DateTime timeTour);
    }
}
