using System;

namespace DailyReportAssignment
{
    class StudentDailyReport
    {
        static void Main()
        {
            Console.WriteLine("The Tech Academy");
            Console.WriteLine("Student Daily Report");
            Console.WriteLine("What course are you on ?");
            string currentCourse = Console.ReadLine();
            Console.WriteLine("What page number?");
            // int currentPage = Convert.ToInt16(Console.ReadLine());
            // I wanted to use this just to use a different data type, but in this case
            // it leaves the door wide open for errors if a non-integer like "page 6"
            // is entered.  So I used strings for everything but the Boolean with the specific
            // instructions.
            string currentPage = Console.ReadLine();
            Console.WriteLine("Do you need help with anything?  Please answer \"true\" or \"false\".");
            bool needHelp = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Were there any positive experiences you'd like to share?  Please give specifics.");
            string positiveExperience = Console.ReadLine();
            Console.WriteLine("Is there any other feedback you'd like to provide?  Please be specific.");
            string feedback = Console.ReadLine();
            Console.WriteLine("How many hours did you study today?");
            string hoursStudied = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Thank you for your answers.  An Instructor will respond to this shortly.  Have a great day!");
            Console.Read();
        }
    }
}
