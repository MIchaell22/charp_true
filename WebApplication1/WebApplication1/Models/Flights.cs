using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Flights
    {
        public int FlightNumber { get; set; }
        public string Froms { get; set; }
        public string Wheres { get; set; }
        public string Airlines { get; set; }
        public int LengthKm { get; set; }
        public TimeSpan? TimeInPath { get; set; }
        public string AircraftType { get; set; }
    }
}
