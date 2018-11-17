using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public static class AnswerChecker
    {
        public static bool IsYes(string answer)
        {
            answer = answer.ToLower();
            bool acceptableAnswer = false;
            if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya") acceptableAnswer = true;
            else if (answer == "no" || answer == "n" || answer == "nope" || answer == "nah") acceptableAnswer = true;

            while (!acceptableAnswer)
            {
                Console.Write("Sorry, we didn't understand your answer.  Please enter \"yes\" or \"no\": ");
                answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya") acceptableAnswer = true;
                else if (answer == "no" || answer == "n" || answer == "nope" || answer == "nah") acceptableAnswer = true;
            }
            if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya") return true;
            else return false;
        }

        public static int IsInt(string answer)
        {
            bool test = Int32.TryParse(answer, out int validInt);
            while (!test)
            {
                Console.Write("Sorry, that is not a valid number.  Please enter a number with no decimal places, letters, or symbols: ");
                answer = Console.ReadLine();
                test = Int32.TryParse(answer, out validInt);
            }
            return validInt;
        }
    }
}
