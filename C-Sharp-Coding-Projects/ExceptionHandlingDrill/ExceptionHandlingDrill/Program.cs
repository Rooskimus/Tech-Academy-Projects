using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingDrill
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> numberList = new List<int>() { 1, 22, 124, 550, 2000, 4 };
                Console.WriteLine("Beep boop. Remote integer list accepted. Boop beep.  User, please enter denominator: ");
                int denominator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Buzz cluck beep.  Denominator accepted.  Initiating turing process...");
                foreach (int number in numberList)
                {
                    int result = number / denominator;
                    Console.WriteLine(result);
                }
                Console.WriteLine("\nTabulation complete.  Terminating turing process.");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Zero is an unnaceptable devisor.  Are you trying to overload my circuits?  Enter a non-zero number, human.");
                return;
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Input is prohibited data type.  Only integers accepted.");
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            finally
            {
                Console.WriteLine("Exiting try/catch block.  Terminating algorithm.  Enjoy your day.");
                Console.Read();
            }


        }
    }
}
