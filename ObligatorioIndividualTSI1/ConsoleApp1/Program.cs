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
            emp.Salary = 12733;
            emp.StartDate = new DateTime(01/01/2018);
            DataAccessLayer.DALEmployeesMongo ie = new DALEmployeesMongo();
            //ie.AddEmployee(emp);
            //emp = (Shared.Entities.FullTimeEmployee)ie.GetEmployee(2);
            //emp.Salary = 3;
            //ie.UpdateEmployee(emp);
            //ie.DeleteEmployee(4);
            //Console.WriteLine(emp.Id);
            //Thread.Sleep(5000);
            //foreach (Shared.Entities.RangeHours rh in ie.DateTimeAllEmployees()) {
             //   Console.WriteLine(rh.EmployeeId +" "+ rh.Hours);
           // }
            //Thread.Sleep(2000);

        }
    }
}
