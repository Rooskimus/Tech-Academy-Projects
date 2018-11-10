using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ListAndArraysDrill
{
    class MisfortuneTeller
    {
        static void Main()
        {
            string[] unpleasantThings = { "Stingy shots.", "Mosquitos.",
                "Mint flavored jelly", "Running out of soap while in the shower.",
                "That feeling that you've forgotten something but you can't remember exactly what it was." };
            Console.Write("Enter a number to see which unpleasant thing awaits you: ");
            string inputUnpleasant = Console.ReadLine();
            int inputUnpleasantCheck = EnterValidNumber(inputUnpleasant);
            inputUnpleasantCheck = EnterValidIndex(inputUnpleasantCheck, unpleasantThings);
            Console.WriteLine("The unpleasant thing that will visit upon you will be: " + unpleasantThings[inputUnpleasantCheck]);
            Console.ReadLine();

            int[] unluckyNumbers = { 21, 13, 72, 3, 8, 2, 1347 };
            Console.Write("Enter a number to see what your unlucky number will be today: ");
            string inputUnlucky = Console.ReadLine();
            int unluckyCheck = EnterValidNumber(inputUnlucky);
            string[] unluckyNumbersString = unluckyNumbers.Select(x => x.ToString()).ToArray(); // This creates a string array from my int array so it may be used by EnterValidIndex which only accepts string arrays.
            unluckyCheck = EnterValidIndex(unluckyCheck, unluckyNumbersString);
            Console.WriteLine("The number you had best avoid today is: " + unluckyNumbers[unluckyCheck]);
            Console.ReadLine();

            List<string> chokeFood = new List<string>();
            string[] foods = { "Bananas." , "Hot Dogs.", "Cucumbers sliced into circles.  Stick-shaped is fine.",
                "Anything spiced with basil." , "Medium-sized oranges.", "Rudabega." };
            chokeFood.AddRange(foods);
            Console.WriteLine("Enter a number and see on which food you will surely choke and die if you consume it today: ");
            string inputFood = Console.ReadLine();
            int inputFoodCheck = EnterValidNumber(inputFood);
            inputFoodCheck = EnterValidIndexList(inputFoodCheck, chokeFood);
            Console.WriteLine("The food that will surely choke you today if you choose to eat it is: " + chokeFood[inputFoodCheck]);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n>> Heed these warnings and have a good day! <<");
            Console.ReadLine();



        }

        static int EnterValidNumber(string x) // This ensures that only integers are passed into the array to seek an index.
        {
            int y;
            while (!Int32.TryParse(x, out y))
            {
                Console.WriteLine("Please enter numbers only: ");
                x = Console.ReadLine();
            }
            return y;
        }

        static int EnterValidIndex(int x, string[] z) // This ensures the user will know what options are available if they do not choose a valid one and prevent errors.
        {
            int zlength = z.Length;
            while (x >= zlength)
            {
                Console.WriteLine("There are only " + zlength + " options, please enter a 0 - " + (zlength - 1)); // I made this relative to whatever string is passed for usability.
                string input = Console.ReadLine();
                x = EnterValidNumber(input);
            }
            return x;
        }

        static int EnterValidIndexList(int x, List<string> z)  // Modified the above subroutine for Lists instead of arrays.
        {
            int zlength = z.Count;
            while (x >= zlength)
            {
                Console.WriteLine("There are only " + zlength + " options, please enter a 0 - " + (zlength - 1));
                string input = Console.ReadLine();
                x = EnterValidNumber(input);
            }
            return x;
        }
    }
}
