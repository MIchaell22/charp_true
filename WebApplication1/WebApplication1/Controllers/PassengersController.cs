using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class PassengersController : Controller
    {
        private readonly IPassengers objpassengers;

        public PassengersController(IPassengers _objpassengers)
        {
            objpassengers = _objpassengers;
        }

        [HttpGet]
        [Route("Index")]
        public IEnumerable<Passengers> Get()
        {
            return objpassengers.GetAllPassengers();
        }

        [HttpPost]
        [Route("Create")]
        public int Create([FromBody] Passengers passengers)
        {
            return objpassengers.AddPassengers(passengers);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public Passengers Details(int id)
        {
            return objpassengers.SelectID_departure(id);
        }

        [HttpPut]
        [Route("Edit")]
        public int Edit([FromBody] Passengers passengers)
        {
            return objpassengers.UpdatePassengers(passengers);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return objpassengers.DellPassengers(id);
        }

    }


}