using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Passengers
    {
        public int IdDeparture { get; set; }
        public int IdPassenger { get; set; }
        public string ServiceClass { get; set; }
        public string PassengerLastname { get; set; }
        public string PassengerName { get; set; }
    }
}
