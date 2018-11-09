using System;

namespace CarInsuranceBoolean
{
    class CarInsuranceBoolean
    {
        static void Main()
        {
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Have you ever had a DUI?  Enter \"true\" or \"false\": ");
            bool dui = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("How many speeding tickets have you had?");
            int speedingTickets = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Qualified?");
            bool qualified = age > 15 && dui == false && speedingTickets <= 3;
            Console.WriteLine(qualified);
            Console.Read();


        }
    }
}
