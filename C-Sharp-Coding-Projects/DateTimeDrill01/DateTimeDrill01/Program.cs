using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeDrill01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It is currently " + DateTime.Now + ".\nEnter a number: ");
            string numberIn = Console.ReadLine();
            bool isDouble = Double.TryParse(numberIn, out double number);
            while (!isDouble)
            {
                Console.WriteLine("Is {0} a number written with digits?  I don't think so.  You should know better.  Shame on you.  \n*sigh* Try again: ", numberIn);
                numberIn = Console.ReadLine();
                isDouble = Double.TryParse(numberIn, out number);
            }
            TimeSpan hoursFuture = TimeSpan.FromHours(number);
            DateTime result = DateTime.Now + hoursFuture;
            Console.WriteLine("\n{0} hours in the future the exact date and time will be {1}.", number, result);
            Console.Read();
        }
    }
}
