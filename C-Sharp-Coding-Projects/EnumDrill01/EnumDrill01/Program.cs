using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDrill01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a day of the week: ");
            string input = Console.ReadLine();   // There's an odd property for enums.  If you enter a number 5 here, it would return Friday, even with the Enum.TryParse code below.
            while (Int32.TryParse(input, out int trash)) // So, I created this as a filter for integers.  Note that if you put in a decimal point it will get filtered by the Enum.TryParse instead.
            {
                Console.WriteLine("The last time a checked, days of the weeks aren't numbers.  Try again: ");
                input = Console.ReadLine();
            }
            bool dayCheck = Enum.TryParse(input, out DayOfWeek userDay);
            while (!dayCheck)
            {
                Console.WriteLine("I know this is asking a lot, but remember how the days of the week are spelled and formatted.  Try again: ");
                dayCheck = Enum.TryParse(Console.ReadLine(), out userDay);
            }
            Console.WriteLine("The day you entered was {0}.  Good job, you can type at least one day of the week correctly!", userDay);
            Console.ReadLine();
        }
    }
}
