using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractice
{
    class MathPractice
    {
        static void Main()
        {
            Console.WriteLine("Enter any number: ");
            double userNumber = Convert.ToDouble(Console.ReadLine());
            double timesFifty = userNumber * 50.0;
            Console.WriteLine("Your number times 50: " + timesFifty);
            double plusTwentyFive = userNumber + 25.0;
            Console.WriteLine("Your number plus 25: " + plusTwentyFive);
            double overTwelvePointFive = userNumber / 12.5;
            Console.WriteLine("Your number divided by 12.5: " + overTwelvePointFive);
            bool greaterFifty = userNumber > 50;
            Console.WriteLine("Your number is over 50: " + greaterFifty);
            double remainder = userNumber % 7.0;
            Console.WriteLine("The remainder of " + userNumber + " divided by 7: " + remainder);
            Console.ReadLine();
        }
    }
}
