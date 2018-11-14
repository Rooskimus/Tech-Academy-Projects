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
            Employee SampleTwo = new Employee() { Id = 001, FirstName = "Test", LastName = "Employee" };
            Employee SampleThree = new Employee() { Id = 002, FirstName = "Unique", LastName = "Employee" };
            Sample.SayName();
            SampleTwo.SayName();
            SampleThree.SayName();
            bool checkOne = Sample == SampleTwo;
            bool checkTwo = Sample == SampleThree;
            Console.WriteLine("Do {0} {1} and {2} {3} have the same ID number?: {4}", Sample.FirstName, Sample.LastName, SampleTwo.FirstName, SampleTwo.LastName, checkOne);
            Console.WriteLine("Do {0} {1} and {2} {3} have the same ID number?: {4}", Sample.FirstName, Sample.LastName, SampleThree.FirstName, SampleThree.LastName, checkTwo);
            Console.ReadLine();
        }

        
    }
}
