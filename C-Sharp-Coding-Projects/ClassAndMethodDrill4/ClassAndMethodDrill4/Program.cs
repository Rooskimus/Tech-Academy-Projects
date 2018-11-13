using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndMethodDrill4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            int output = 0;
            Console.WriteLine("Let's perform a math operation on two integers.");
            Console.Write("Please choose your first integer: ");
            string inOne = Console.ReadLine();
            bool isIntOne = int.TryParse(inOne, out int inputOne);
            while (!isIntOne)
            {
                Console.WriteLine("Please enter a valid integer: ");
                inOne = Console.ReadLine();
                isIntOne = int.TryParse(inOne, out inputOne);
            }


            Console.Write("OK, and now your second.  This one is optional, you may simply press enter if you please: ");
            string inTwo = Console.ReadLine();
            bool isIntTwo = int.TryParse(inTwo, out int inputTwo);
            if (isIntTwo)
            {
                output = myClass.MyMethod(inputOne, inputTwo);
            }
            else
            {
                output = myClass.MyMethod(inputOne);
            }
            Console.WriteLine("Your result is: {0}", output);
            Console.Read();
        }
    }
}
