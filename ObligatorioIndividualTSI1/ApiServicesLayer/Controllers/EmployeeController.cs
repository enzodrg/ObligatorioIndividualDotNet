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
    public class EmployeeController : ApiController
    {
        private IBLEmployees iblOps = new BLEmployees();
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return iblOps.GetAllEmployees();
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return iblOps.GetEmployee(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Employee emp)
        {
            iblOps.AddEmployee(emp);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Employee emp)
        {
            iblOps.UpdateEmployee(emp);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            iblOps.DeleteEmployee(id);
        }
    }
}