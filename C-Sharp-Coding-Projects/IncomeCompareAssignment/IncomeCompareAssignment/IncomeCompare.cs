using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeCompareAssignment
{
    class IncomeCompare
    {
        static void Main()
        {
            Console.WriteLine("Anonymous Income Comparison Program");
            Console.WriteLine("Person 1");
            Console.WriteLine("How many hours does Person 1 work per week?");
            float person1Hours = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("What is Person 1's hourly wage?");
            float person1Wage = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Person 2");
            Console.WriteLine("How many hours does Person 2 work per week?");
            float person2Hours = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("What is Person 2's hourly wage?");
            float person2Wage = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Results:");
            Console.WriteLine("Annual salary of Person 1:");
            double person1Yearly = person1Hours * person1Wage * 52;
            Console.WriteLine(person1Yearly.ToString("c2")); //using .ToString("c2") converts to a two-decimal place currency for display.
            Console.WriteLine("Annual salary of Person 2:");
            double person2Yearly = person2Hours * person2Wage * 52;
            Console.WriteLine(person2Yearly.ToString("c2"));
            bool person1Greater = person1Yearly > person2Yearly;
            Console.WriteLine("Does Person 1 make more money than Person 2?");
            Console.WriteLine(person1Greater);
            Console.ReadLine();
        }
    }
}
