using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodDrill1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 Test = new Class1();
            Console.Write("Please enter a number: ");
            string userInput = Console.ReadLine();
            bool uInputCheck = Int32.TryParse(userInput, out int uInput);
            while (!uInputCheck)
            {
                Console.Write("Please enter a valid integer: ");
                userInput = Console.ReadLine();
                uInputCheck = Int32.TryParse(userInput, out uInput);
            } 

            Test.DivideByTwo(uInput, out int uOutput);
            Console.WriteLine("{0} divided by two is {1}.", uInput, uOutput);
            Console.ReadLine();

            Console.Clear();
            Console.Write("Vegeta and Nappa landed right in front of you.  They're scanning you to see your power level!  \nQuick, power up and enter your power level: ");
            string powerLevel = Console.ReadLine();
            StaticClass.Over9000(powerLevel, out double pushups, out double seconds);
            if (pushups >= 0)
            {
                Console.WriteLine("Vegeta: Ha!  This punk's not so tough.  \nHe'd have to do at least {0} more pushups at 20Gs to stand a chance.  \nI bet you can beat him in {1} seconds, Nappa! \nNappa proceeds to destroy you.  You lose.", pushups, seconds);
            }
            Console.Read();
        }
    }
}
