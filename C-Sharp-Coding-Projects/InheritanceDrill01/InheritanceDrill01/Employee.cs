using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDrill01
{
    public class Employee<T> : Person
    {
        public int Id { get; set; }
        public List<T> Things { get; set; }

        public static bool operator == (Employee<T> employeeOne, Employee<T> employeeTwo)
        {
            return employeeOne.Id == employeeTwo.Id;
        }

        public static bool operator != (Employee<T> employeeOne, Employee<T> employeeTwo)
        {
            return !(employeeOne == employeeTwo); // uses the above == operator
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
