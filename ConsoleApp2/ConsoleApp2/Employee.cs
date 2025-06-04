using ConsoleApp2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Employee : IEntity
    {
        public Employee()
        {
            Id = IdCounter;
            IdCounter++;
        }

        private static int IdCounter = 0;
        public int Id {  get; }
        public string Name { get; set; }
        public double Salary { get; set; }


        public void ShowInfo()
        {
            Console.WriteLine($"Id:{Id}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Salary:{Salary}");

        }
    }
}
