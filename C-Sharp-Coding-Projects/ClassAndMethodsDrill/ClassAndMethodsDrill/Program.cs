using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm going to perform math beyond your comprehension using three subroutines stored in a class outside of this program.\nI know, mindblowing...\nSo what number will you start with?: ");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input recieved. Mind blowing math happening....now!");
            int output = Operations.MinusOne(Operations.TimesThree(Operations.AddFive(input))); // This should do input + 5, result of that * 3, result of that - 1.
            // Based on how the drill is worded, I wasn't sure if it wanted one combined output or three seperate ones.  So, just in case:
            int outputOne = Operations.AddFive(input);
            int outputTwo = Operations.MinusOne(input);
            int outputThree = Operations.TimesThree(input);

            Console.WriteLine("After much muy difficult math, your number has become " + output + ".");
            Console.WriteLine("Alternatively, your inputs could become " + outputOne + ", " + outputTwo + ", " + outputThree + ".");
            Console.Read();
        }
    }
}
