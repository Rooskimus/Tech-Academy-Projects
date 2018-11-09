using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileAndDoWhile
{
    class NumberGame
    {
        static void Main()
        {
            Console.WriteLine("Let's play a game!  I'm thinking of a number between 1 and 1000.");
            Console.WriteLine("Guess a number and I'll tell you if the answer is higher or lower.");
            Console.WriteLine("Keep guessing until you get the right number.  Here we go!");
            Console.Write("Guess a number: ");
            Random rnd = new Random();
            int correctNumber = rnd.Next(1001);
            string numberString = Console.ReadLine();
            int number = EnterNumber(numberString);
            do
            {
                if (number < correctNumber)
                {
                    Console.Write("Higher!  Guess again: ");
                    numberString = Console.ReadLine();
                    number = EnterNumber(numberString);
                }
                else if (number > correctNumber)
                {
                    Console.Write("Lower!  Guess again: ");
                    numberString = Console.ReadLine();
                    number = EnterNumber(numberString);
                }
            }
            while (number != correctNumber);
            Console.WriteLine("You got it!  " + number + " is right!");
            Console.ReadLine();
        }

        static int EnterNumber(string x)
        {
            int number;
            while (!Int32.TryParse(x, out number))
            {
                Console.WriteLine("");
                Console.WriteLine("Mr. T: I pity the fool who don't write a whole number!");
                Console.WriteLine("");
                Console.Write("Try putting in a number this time or risk disappointing Mr. T again: ");
                x = Console.ReadLine();
            }
            return number;
        }
    }
}
