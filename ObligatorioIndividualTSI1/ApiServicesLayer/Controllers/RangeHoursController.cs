using BusinessLogicLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiServices.Controllers
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
