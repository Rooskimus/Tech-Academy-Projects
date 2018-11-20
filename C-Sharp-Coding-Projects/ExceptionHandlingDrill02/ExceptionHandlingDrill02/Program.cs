using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingDrill02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your age: ");
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());
                if (age < 1) throw new ArgumentException();
                int birthYear = DateTime.Now.Year - age;
                Console.WriteLine("You were born in {0}!", birthYear);
                Console.Read();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("\nAre you really either gestating or a still just a glimmer in your Father's eye?\nI dont' think so.  Try entering a number greater than zero next time! ");
                Console.Read();
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("\nWhoa.  Something went wrong that we could not have possibly foreseen.  ABORT!  ABORT!");
                Console.Read();
                return;
            }
        }
    }
}
