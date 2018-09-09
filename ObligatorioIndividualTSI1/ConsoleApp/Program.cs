using System;
using Shared;
using DataAccessLayer;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Shared.Entities.FullTimeEmployee emp = new Shared.Entities.FullTimeEmployee();
            emp.Name = "hb";
            emp.Salary = 1273;
            emp.StartDate = new DateTime();
            DataAccessLayer.DALEmployeesEF ie = new DALEmployeesEF();
            ie.AddEmployee(emp);
        }
    }
}
