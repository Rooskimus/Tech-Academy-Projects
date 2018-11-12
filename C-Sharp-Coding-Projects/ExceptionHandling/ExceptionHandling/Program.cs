using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try // Anything that will be checked for errors goes here.
            {
                Console.WriteLine("Pick a number: ");
                int numberOne = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pick another number: ");
                int numberTwo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dividing the two...");
                int numberThree = numberOne / numberTwo;
                Console.WriteLine(numberOne + " divided by " + numberTwo + " is " + numberThree);
                Console.Read();
            }
            catch (FormatException ex) // Specific errors may be caught and dealt with individually
            {
                Console.WriteLine("Please type a whole number.");
                return; // used to break out of the program.
            }
            catch (DivideByZeroException ex) // Another specific error.
            {
                Console.WriteLine("You can't divide by zero, silly goose.");
                return;
            }
            catch (Exception ex) // This will catch any unforseen errors
            {
                Console.WriteLine(ex.Message); // This simply returns the default error message for any error.
                return;
            }
            finally // This runs before the program ends regardless of what's in the catches.  Without this, we wouldn't see the error
                    // messages from above as the program would just end at the return.
            {
                Console.Read();
            }

        }
    }
}
