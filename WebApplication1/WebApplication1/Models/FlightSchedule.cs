using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class FlightSchedule
    {
        public int IdDeparture { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int DepartureNumber { get; set; }

        public virtual Flights FlightNumberNavigation { get; set; }
        public virtual Passengers IdDepartureNavigation { get; set; }
    }
}
