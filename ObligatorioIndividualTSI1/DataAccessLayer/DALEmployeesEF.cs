using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        Model.ObligatorioIndividualNETEntities db = new Model.ObligatorioIndividualNETEntities();
        
        public void AddEmployee(Employee emp)
        {
            if (emp!=null)
            {

                if (emp is FullTimeEmployee)//if (emp.GetType() == typeof(Shared.Entities.FullTimeEmployee))
                {
         
                    Model.FullTimeEmployee castEmp = new Model.FullTimeEmployee() {  EmployeeId=emp.Id, Name=emp.Name, Salary=((FullTimeEmployee)emp).Salary, StartDate=emp.StartDate };
                    db.Employees.Add(castEmp);
                    db.SaveChanges();
                } else {
                    Model.PartTimeEmployee castEmp = new Model.PartTimeEmployee() { EmployeeId = emp.Id, Name = emp.Name, StartDate = emp.StartDate, HourlyRate= ((PartTimeEmployee)emp).HourlyRate };
                    db.Employees.Add(castEmp);
                    db.SaveChanges();
                }
            }
            
       
        }

        public void DeleteEmployee(int id)
        {
            Model.Employee emp = db.Employees.Find(id);
            if (emp!=null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }

            
        }

        public void UpdateEmployee(Employee emp)
        {
            if (emp is FullTimeEmployee)
                {
                Model.FullTimeEmployee castEmp =(Model.FullTimeEmployee)db.Employees.Find(emp.Id);
                castEmp.EmployeeId = emp.Id;
                castEmp.Name = emp.Name;
                castEmp.StartDate = emp.StartDate;
                castEmp.Salary = ((FullTimeEmployee)emp).Salary;
                db.Entry(castEmp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                } else {
                Model.PartTimeEmployee castEmp = (Model.PartTimeEmployee)db.Employees.Find(emp.Id);
                castEmp.EmployeeId = emp.Id;
                castEmp.Name = emp.Name;
                castEmp.StartDate = emp.StartDate;
                castEmp.HourlyRate = ((PartTimeEmployee)emp).HourlyRate;
                db.Entry(castEmp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees =new List<Employee>();

            foreach (Model.Employee e in db.Employees.ToList()) {
                if (e!= null)
                {
                    if (e.GetType() == typeof(Model.FullTimeEmployee))
                    {

                        FullTimeEmployee castEmp = new FullTimeEmployee() {  Id = e.EmployeeId,
                                                                                  Name = e.Name,
                                                                                  Salary = (int)((Model.FullTimeEmployee)e).Salary,
                                                                                  StartDate = e.StartDate };
                        employees.Add(castEmp);
                    }
                    else
                    {
                        PartTimeEmployee castEmp = new PartTimeEmployee() { Id = e.EmployeeId,
                                                                            Name = e.Name,
                                                                            StartDate = e.StartDate,
                                                                            HourlyRate = (int)((Model.PartTimeEmployee)e).HourlyRate };

                        employees.Add(castEmp);
                    }
                }
            }
            return employees ;
        }

        public Employee GetEmployee(int id)
        {
            Model.Employee e = db.Employees.Find(id);
            if (e!=null)
            {
                    if (e.GetType() == typeof(Model.FullTimeEmployee))
                    {

                        FullTimeEmployee emp = new FullTimeEmployee()
                        {
                            Id = e.EmployeeId,
                            Name = e.Name,
                            Salary = (int)((Model.FullTimeEmployee)e).Salary,
                            StartDate = e.StartDate
                        };
                    return emp;
                        
                    }
                    else
                    {
                        PartTimeEmployee emp = new PartTimeEmployee()
                        {
                            Id = e.EmployeeId,
                            Name = e.Name,
                            StartDate = e.StartDate,
                            HourlyRate = (int)((Model.PartTimeEmployee)e).HourlyRate
                        };
                    return emp;
                    }

            }
            else { 
            return null;
            }
        }

        public void addDateTimeEmployee(RangeHours rH)
        {
            Model.RangeHour castRH = new Model.RangeHour() { };
            db.RangeHours.Add(castRH);
            db.SaveChanges();
        }

        public List<RangeHours> DateTimeAllEmployees()
        {
            List<RangeHours> rhlist = new List<RangeHours>();
            foreach(Model.RangeHour rH in db.RangeHours.ToList())
            {
                RangeHours castRH =new RangeHours(rH.EmployeeId, rH.Hours, rH.StartDate);
                rhlist.Add(castRH);
            }
            return rhlist;
        }
    }
    
}
