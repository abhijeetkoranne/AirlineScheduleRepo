using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PublicTimetable.Models
{
    public class AirlineSchedule
    {
        [Key]
        public string FlightNumber { get; set; }
        public string StartPeriodOfOperation { get; set; }
        public string EndPeriodOfOperation { get; set; }
        public string DaysOfOperation { get; set; }
        public string DepartureTime { get; set; }
        public string OriginStation { get; set; }
        public string DestinationStation { get; set; }
        public string Aircraft { get; set; }

    }
}
