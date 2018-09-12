using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shared.Entities.FullTimeEmployee emp = new Shared.Entities.FullTimeEmployee();
            emp.Name = "hbf";
            emp.Salary = 1;
            emp.StartDate = DateTime.Now;
            DataAccessLayer.DALEmployeesMongo ie = new DALEmployeesMongo();
            ie.AddEmployee(emp);
            //ie.AddEmployee(emp);
            //emp = (Shared.Entities.FullTimeEmployee)ie.GetEmployee(2);
            //emp.Salary = 3;
            //ie.UpdateEmployee(emp);
           // ie.DeleteEmployee(2);
            //Console.WriteLine(emp.Id);
            //Thread.Sleep(5000);
            //foreach (Shared.Entities.RangeHours rh in ie.DateTimeAllEmployees()) {
            //  Console.WriteLine(rh.EmployeeId +" "+ rh.Hours);
            // }
            //Console.WriteLine(ie.GetEmployee(7).StartDate);
            //Thread.Sleep(2000);

        }
    }
}
