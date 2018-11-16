using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFunctionDrill01
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeAdder employees = new EmployeeAdder();
            List<Employee> employeeList = new List<Employee>();
            employees.Add(employeeList, "Bob", "Bojangles");
            employees.Add(employeeList, "Joe", "Jobangles");
            employees.Add(employeeList, "Tim", "Tojangles");
            employees.Add(employeeList, "Laura", "Lotangles");
            employees.Add(employeeList, "Mary", "Molangles");
            employees.Add(employeeList, "Joe", "Jomangles");
            employees.Add(employeeList, "Teresa", "Tojangles");
            employees.Add(employeeList, "Ragnar", "Ratangles");
            employees.Add(employeeList, "Ingrid", "Iorangles");
            employees.Add(employeeList, "David", "Doiangles");

            List<Employee> justJoe = new List<Employee>();
            foreach (Employee emp in employeeList)
            {
                if (emp.FirstName == "Joe")
                {
                    justJoe.Add(emp);
                }
            }

            Console.WriteLine("Output from the Joe foreach loop: \n");
            foreach (Employee joe in justJoe)
            {
                Console.WriteLine("{0} {1} {2}", joe.ID, joe.FirstName, joe.LastName);
            }

            Console.WriteLine("\nOutput from the Joe Lambda expression: \n");
            List<Employee> justJoe2 = employeeList.Where<Employee>(x => x.FirstName == "Joe").ToList<Employee>();
            foreach (Employee joe in justJoe2)
            {
                Console.WriteLine("{0} {1} {2}", joe.ID, joe.FirstName, joe.LastName);
            }

            Console.WriteLine("\nOutput from the ID over 5 Lambda expression: \n");
            List<Employee> idOverFive = employeeList.Where<Employee>(x => x.ID > 5).ToList<Employee>();
            foreach (Employee slave in idOverFive)
            {
                Console.WriteLine("{0} {1} {2}", slave.ID, slave.FirstName, slave.LastName);
            }

            Console.ReadLine();
        }
    }
}
