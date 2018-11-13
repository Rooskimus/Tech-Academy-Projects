using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDrill01
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Sample = new Employee() { Id = 001, FirstName = "Sample", LastName = "Student" };
            Sample.SayName();
            Console.ReadLine();
        }
    }
}
