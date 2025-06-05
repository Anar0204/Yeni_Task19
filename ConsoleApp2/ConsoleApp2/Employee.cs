using ConsoleApp2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Employee : IEntity,IComparable<Employee>
    {
        private static int IdCounter = 0;

        public Employee()
        {
            Id = IdCounter;
            IdCounter++;
        }

        [JsonConstructor]
        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
            if (id >= IdCounter)
                IdCounter = id + 1; 
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public double Salary { get; set; }


        public void ShowInfo()
        {
            Console.WriteLine($"Id:{Id}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Salary:{Salary}");

        }

        public int CompareTo(Employee? other)
        {
            if (other == null) return 1; 
            return Salary.CompareTo(other.Salary); 
        }
    }
}
