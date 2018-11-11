using System;
using System.Collections.Generic;

namespace IterationTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testScores = { 98, 99, 85, 70, 82, 34, 91, 99, 94 };

            for (int i = 0; i < testScores.Length; i++)  // Basic way to iterate through an array.  It will perform whatever command comes next for each item.
            {
                if (testScores[i] > 85)
                {
                    Console.WriteLine("Passing test score: " + testScores[i]);
                }
            }
            Console.WriteLine("");
            //Console.ReadLine();

            string[] names = { "Jesse", "Eric", "Paul", "Adam", "Andrew" };

            for (int j = 0; j < names.Length; j++)  // Can be done the same way with a string or any other data type.  This one simply shows you what's inside with no conditions.
            {
                Console.WriteLine(names[j]);
            }
            Console.WriteLine("");
            //Console.ReadLine();

            List<int> testScores2 = new List<int>();  // Now creating and using a list.
            testScores2.AddRange(testScores);         // Instead of adding each element individually, bringing in our already existing array into the list.
            testScores2.Add(86);                      // Adding a single element to the end of the list.

            foreach (int score in testScores2)        // foreach accomplishes the same thing as the for loop above in simpler to read form; declared score as a new variable.
            {
                if (score > 85)
                {
                    Console.WriteLine("Passing test score: " + score); // Prints the same list as above, but now with our added number and using list syntax.
                }
            }
            Console.WriteLine("");
            //Console.ReadLine();

            List<string> names2 = new List<string>() { "Andrew", "Eric", "Adam", "Daniel", "Jesse" };  // list and array names are usually plural

            foreach (string name in names2)
            {
                Console.WriteLine(name); 
            }
            Console.WriteLine("");
            //Console.ReadLine();

            // We can create a list and fill it with values from another list based on certain conditions.
            List<int> passingScores = new List<int>();  // Our new list of only passing scores.

            foreach (int score in testScores2) // for every score in our list of scores.
            {
                if (score > 85)               // which is passing (above 85)
                {
                    passingScores.Add(score); // add to our new list of passing scores.
                }
            }
            Console.WriteLine(passingScores.Count); // and let's see how many passing scores there were in total.
            Console.ReadLine();
        }
    }
}
