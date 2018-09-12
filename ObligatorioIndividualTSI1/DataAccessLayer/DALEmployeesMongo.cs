using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataAccessLayer
{
    public class DALEmployeesMongo : IDALEmployees
    {
        private readonly IMongoDatabase db = new MongoClient().GetDatabase("Employee");

        public void AddEmployee(Employee emp)
        {
            if (emp != null)
            
            {//si el empleado tiene algo
                var collection = db.GetCollection<BsonDocument>("Employee");
                var collectionEmp = db.GetCollection<Employee>("Employee");
                //creo la colleccion
                var listEmployees = collection.Find(new BsonDocument()).ToList();
                //traigo todos los documentos
                if (listEmployees.Count == 0)
                {//si la colleccion esta vacia
                    collectionEmp.InsertOne(emp);
                    //lo guardo
                }
                else
                {
                    int count = 0;
                    foreach (BsonDocument bs in listEmployees)
                    {
                        int id = (int)bs.GetElement("_id").Value;
                        if (id > count) { count = (int)bs.GetElement("_id").Value; }
                    }
                    emp.Id = count + 1;
                    collectionEmp.InsertOne(emp);
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            var collection = db.GetCollection<Employee>("Employee");
            collection.DeleteOne(e => e.Id == id);

        }

        public void UpdateEmployee(Employee emp)
        {
            if (emp != null)
            {
                if (emp.GetType() == typeof(FullTimeEmployee))
                {
                    var filter = Builders<Employee>.Filter.Eq(s => s.Id, emp.Id);
                    var update = Builders<Employee>.Update.Set("Id", emp.Id).Set("Name", emp.Name).Set("StartDate", emp.StartDate).Set("Salary", ((FullTimeEmployee)emp).Salary);
                    var result = db.GetCollection<Employee>("Employee").UpdateOne(filter, update);
                }
                else
                {
                    //PartTimeEmployee
                    var filter = Builders<Employee>.Filter.Eq(s => s.Id, emp.Id);
                    var update = Builders<Employee>.Update.Set(e => e.Id, emp.Id).Set(e => e.Name, emp.Name).Set(e => e.StartDate, emp.StartDate).Set(e => ((PartTimeEmployee)e).HourlyRate, ((PartTimeEmployee)emp).HourlyRate);
                    var result = db.GetCollection<Employee>("Employee").UpdateOne(filter, update);
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {   
            var collection = db.GetCollection<BsonDocument>("Employee");
            var collectionEmp = db.GetCollection<Employee>("Employee");
            //creo la colleccion
            var listEmployees = collection.Find(new BsonDocument()).ToList();
            List<Employee> employees = new List<Employee>();
            foreach (BsonDocument employee in listEmployees)
            {

                if (employee.GetValue("_t").ToString().Equals("FullTimeEmployee"))
                {
                    FullTimeEmployee emp = new FullTimeEmployee()
                    {
                        Id = (int)employee.GetValue("_id"),
                        Name = employee.GetValue("StartDate").ToString(),
                        StartDate = (DateTime)employee.GetValue("StartDate"),
                        Salary = (int)employee.GetValue("Salary")
                    };
                    employees.Add(emp);
                }
                else
                {
                    PartTimeEmployee emp = new PartTimeEmployee()
                    {
                        Id = (int)employee.GetValue("_id"),
                        Name = employee.GetValue("StartDate").ToString(),
                        StartDate = (DateTime)employee.GetValue("StartDate"),
                        HourlyRate = (int)employee.GetValue("HourlyRate")
                    };
                    employees.Add(emp);

                }

            }
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var collection = db.GetCollection<BsonDocument>("Employee");
            //creo la colleccion
            var employee = collection.Find(Builders<BsonDocument>.Filter.Eq("_id", id)).FirstOrDefault();
            if (employee != null)
            {
                if (employee.GetValue("_t").ToString().Equals("FullTimeEmployee"))
                {
                    FullTimeEmployee emp = new FullTimeEmployee()
                    {
                        Id = (int)employee.GetValue("_id"),
                        Name = employee.GetValue("StartDate").ToString(),
                        StartDate = (DateTime)employee.GetValue("StartDate"),
                        Salary = (int)employee.GetValue("Salary")
                    };
                    return emp;
                }
                else
                {
                    PartTimeEmployee emp = new PartTimeEmployee()
                    {
                        Id = (int)employee.GetValue("_id"),
                        Name = employee.GetValue("StartDate").ToString(),
                        StartDate = (DateTime)employee.GetValue("StartDate"),
                        HourlyRate = (int)employee.GetValue("HourlyRate")
                    };
                    return emp;

                }

            }
            else { return null; }
        }

        public void addDateTimeEmployee(RangeHours rH)
        {

            var collection = db.GetCollection<RangeHours>("RangeHours");
            collection.InsertOne(rH);

        }

        public List<RangeHours> DateTimeAllEmployees()
        {
            var collection = db.GetCollection<BsonDocument>("RangeHours");
            var collectionRH = db.GetCollection<Employee>("RangeHours");
            //creo la colleccion
            var listRHaux = collection.Find(new BsonDocument()).ToList();
            List<RangeHours> listRH = new List<RangeHours>();
            foreach (BsonDocument rHaux in listRHaux)
            {
                RangeHours rH = new RangeHours((int)rHaux.GetValue("EmployeeId"), (int)rHaux.GetValue("Hours"), (DateTime)rHaux.GetValue("StartDate"));
                listRH.Add(rH);
            }
            return listRH;
        }
    }
}
