using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFunctionDrill01
{
    public class EmployeeAdder : Employee
    {
        public List<Employee> EmployeeList { get; set; }

        public List<Employee> Add(List<Employee> list, string firstName, string lastName)
        {
            Employee newEmployee = new Employee() { FirstName = firstName, LastName = lastName };
            list.Add(newEmployee);
            int employeeIndex = list.IndexOf(newEmployee) + 1; // We're not allowing and ID of 0 so we add 1.
            newEmployee.ID = employeeIndex;
            return list;
        }
    }
}
