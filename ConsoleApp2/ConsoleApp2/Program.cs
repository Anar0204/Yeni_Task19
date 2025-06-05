
using ConsoleApp2;
using System.Runtime.InteropServices;

string root = "C:\\Users\\Asus\\Desktop\\ConsoleApp2\\ConsoleApp2";

if (!Directory.Exists($"{root}\\Files"))
{
    Directory.CreateDirectory($"{root}\\Files");
}

string dirRoot = $"{root}\\Files";

if (!File.Exists(dirRoot + "\\database.json"))
{
    using FileStream fs = File.Create(dirRoot + "\\database.json");
}


bool check = false;
string op;
Department department = new Department();
do
{
    Console.WriteLine("1.Add Employee");
    Console.WriteLine("2. Get employee by id");
    Console.WriteLine("3. Remove employee");
    Console.WriteLine("0. Quit");
    op = Console.ReadLine();

    switch (op)
    {
        case "1":
            Employee employee = new Employee();
            Console.WriteLine("Ad:");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Maas:");
            employee.Salary = Convert.ToInt32(Console.ReadLine());
            department.AddEmployee(employee);
            break;
        case "2":
            Console.WriteLine("Idni daxil edin ");
            int id1 = Convert.ToInt32(Console.ReadLine());

            Employee employee1 = department.GetEmployeeById(id1);

            Console.WriteLine($"Employee:{employee1.Name}");
            break;
        case "3":
            int id2 = Convert.ToInt32(Console.ReadLine());

            department.RemoveEmployee(id2);
            break;
        case "0":
            check = true;
            break;
    }

}
while (!check);
