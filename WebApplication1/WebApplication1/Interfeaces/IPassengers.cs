using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    public interface IPassengers
    {
        IEnumerable<Passengers> GetAllPassengers();
         int AddPassengers(Passengers passengers);
        int UpdatePassengers(Passengers passengers);
        Passengers SelectID_departure(int id);
        int DellPassengers(int id);
       
    }
}
