using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
       private IDALEmployees _dal;

        public BLEmployees()
        {
            _dal = new DALEmployeesMongo();
        }

        public void AddEmployee(Employee emp)
        {
            _dal.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
        }

        public void UpdateEmployee(Employee emp)
        {
           _dal.UpdateEmployee(emp);
        }

        public List<Employee> GetAllEmployees()
        {
           return _dal.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _dal.GetEmployee(id);
        }

        public void addDateTimeEmployee(RangeHours rH) {
            _dal.addDateTimeEmployee(rH);
        }

        public List<RangeHours> DateTimeAllEmployees() {
            return _dal.DateTimeAllEmployees();
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
             /*
             calcular el salario a pagar a un empleado part-time de acuerdo a las horas que se indiquen que ha trabajado. hours*hourlyrate
             En caso de que el empleado no exista o que no sea un empleado part-time la operación debe arrojar una excepción controlada específica 
             null or error de tipo.
             */
             Employee emp = GetEmployee(idEmployee);
            if (emp == null)
            { throw new Shared.Exception.MissingEmployeeException("El empleado no existe"); }
            else if (emp.GetType() == typeof(FullTimeEmployee)) { throw new Shared.Exception.WrongEmployeeType("Es un empleado de tipo tiempo completo"); }
            else
            {
                return ((PartTimeEmployee)emp).HourlyRate * (double)hours;
            }
        }
    }
}
