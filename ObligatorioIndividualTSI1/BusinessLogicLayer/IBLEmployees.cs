﻿using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBLEmployees
    {
        void AddEmployee(Employee emp);

        void DeleteEmployee(int id);

        void UpdateEmployee(Employee emp);

        List<Employee> GetAllEmployees();

        Employee GetEmployee(int id);

        double CalcPartTimeEmployeeSalary(int idEmployee, int hours);

        void addDateTimeEmployee(RangeHours rH);

        List<RangeHours> DateTimeAllEmployees();
    }
}
