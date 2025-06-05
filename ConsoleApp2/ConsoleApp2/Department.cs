using ConsoleApp2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Department : IEntity
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        private List<Employee> Employees = new List<Employee>();
        const string path = "C:\\Users\\Asus\\Desktop\\ConsoleApp2\\ConsoleApp2\\Files\\database.json";

        public void AddEmployee(Employee employee)
        {
            if (employee == null) throw new NullReferenceException();

            Employees.Add(employee);

            string root = "C:\\Users\\Asus\\Desktop\\ConsoleApp2\\ConsoleApp2\\database.json";

            SerializeEmployee(employee);

        }
        public Employee GetEmployeeById(int id)
        {
            if(id == null) throw new NullReferenceException();

            List<Employee> employees2 = new List<Employee>();

            employees2 = DeSerializeEmployee();

            Employee employee = employees2.FirstOrDefault(x =>x.Id ==id);

            if(employee == null) throw new NotFoundException();

            return employee;
        }
        public void RemoveEmployee(int id)
        {
            if(id ==null) throw new NullReferenceException();

            List<Employee> employees = DeSerializeEmployee();

            employees.Distinct();

            employees.RemoveAt(id);

            File.WriteAllText(path, "[]");

            using FileStream fs = File.OpenWrite(path);


            JsonSerializer.Serialize(fs, employees);

        }
        public static void SerializeEmployee( Employee employee)
        {
            List<Employee> employees = DeSerializeEmployee();

            employees.Distinct();

            File.WriteAllText(path, "[]");

            employees.Add(employee);

            using FileStream fs = File.OpenWrite(path);


            JsonSerializer.Serialize(fs, employees);

        }
        public static List<Employee> DeSerializeEmployee()
        {

            using FileStream fs = File.OpenRead(path);

            using StreamReader streamReader = new StreamReader(fs);

            string json = streamReader.ReadToEnd();

            if (string.IsNullOrWhiteSpace(json))
                return new List<Employee>();

            List<Employee> employees1 = JsonSerializer.Deserialize<List<Employee>>(json);

            if (employees1 == null)
            {
                return null;
            }

            return employees1;
        }



    }
}
