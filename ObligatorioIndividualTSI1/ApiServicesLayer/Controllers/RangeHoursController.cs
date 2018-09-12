using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer;
using Shared.Entities;

namespace ApiServicesLayer.Controllers
{
    public class RangeHoursController : ApiController
    {
        private IBLEmployees iblOps = new BLEmployees();
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return iblOps.GetAllEmployees();
        }

        // POST api/<controller>
        public void Post([FromBody]RangeHours rH)
        {
            iblOps.addDateTimeEmployee(rH);
        }
    }
}
