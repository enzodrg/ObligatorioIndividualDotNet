﻿using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesNativeSQL : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void addDateTimeEmployee(RangeHours rH)
        {

            throw new NotImplementedException();

        }
        public List<RangeHours> DateTimeAllEmployees()
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}