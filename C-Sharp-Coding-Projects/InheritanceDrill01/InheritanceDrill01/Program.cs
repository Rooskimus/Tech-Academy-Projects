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
            // Code for previous drills (made all data types string so it will still work)
            Employee<string> Sample = new Employee<string>() { Id = 001, FirstName = "Sample", LastName = "Student" };
            Employee<string> SampleTwo = new Employee<string>() { Id = 001, FirstName = "Test", LastName = "Employee" };
            Employee<string> SampleThree = new Employee<string>() { Id = 002, FirstName = "Unique", LastName = "Employee" };
            Sample.SayName();
            SampleTwo.SayName();
            SampleThree.SayName();
            bool checkOne = Sample == SampleTwo;
            bool checkTwo = Sample == SampleThree;
            Console.WriteLine("Do {0} {1} and {2} {3} have the same ID number?: {4}", Sample.FirstName, Sample.LastName, SampleTwo.FirstName, SampleTwo.LastName, checkOne);
            Console.WriteLine("Do {0} {1} and {2} {3} have the same ID number?: {4}", Sample.FirstName, Sample.LastName, SampleThree.FirstName, SampleThree.LastName, checkTwo);
            Console.ReadLine();

            // Code for drill on step 131

            Employee<string> jackBower = new Employee<string>() { Id = 003, FirstName = "Jack", LastName = "Bower", Things = new List<string>()
            { "Gun", "Fake Passport", "Earpiece", "Bucket Full of Kick-Ass", "At least two recently sustained gunshot wounds" } };
            Employee<int> nerdGuy = new Employee<int>() { Id = 004, FirstName = "Nerd", LastName = "Guy", Things = new List<int>() { 1, 3, 5, 7, 13, 17, 23, 27 } };

            List<string> allTheThings = new List<string>();
            allTheThings.AddRange(jackBower.Things);
            allTheThings.AddRange(nerdGuy.Things.ConvertAll<string>(delegate (int i) { return i.ToString(); })); // This was hard to find!
            foreach (string thing in allTheThings)
            {
                Console.WriteLine(thing);
            }
            Console.ReadLine();
            
            // My simpler way just involved two foreach loops, but I wasn't sure if that was what was being asked for:
            // foreach (string thing in jackBower.Things) {Console.WriteLine(thing);}
            // foreach (int thing in nerdGuy.Things) {Console.WriteLine(thing);}
            // which also worked and was way easier.
        }

        
    }
}
