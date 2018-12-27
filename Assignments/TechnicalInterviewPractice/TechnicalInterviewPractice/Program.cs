using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInterviewPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sum odd numbers in an integer array
            int[] testArray = { 1, 2, 3, 4, 5, 6, 7 };
            int oddTotal = OddTotal(testArray);
            Console.WriteLine("Sum of odd numbers in the array: {0}", oddTotal);
            Console.ReadLine();

            // Sum larger integers
            int[] testArrayTwo = { 2000000000, 1000000000, 2000000000 };
            decimal largeTotal = LargeIntSummer(testArrayTwo);
            Console.WriteLine("Sum of large integers: {0}", largeTotal);
            Console.ReadLine();

            // String Reverser
            string testString = "!ereht olleH";
            string reversed = StringReverser(testString);
            Console.WriteLine("\"{0}\" reversed is \"{1}\"", testString, reversed);
            Console.ReadLine();

            // Remove repeat characters
            string testStringTwo = "Teeeeeexxxxaaaassss";
            string removed = RepeatRemover(testStringTwo);
            Console.WriteLine("\"{0}\" with repeated characters removed is \"{1}\"", testStringTwo, removed);
            Console.ReadLine();

            //FizzBuzz!
            FizzBuzz();

        }

        // Sum odd numbers in an integer array
        public static int OddTotal(int[] intArray)
        {
            List<int> odds = new List<int>();
            for (int i = 0; i < intArray.Length; i++)
            {
                int oddCheck = intArray[i] % 2;
                if (oddCheck != 0)
                {
                    odds.Add(intArray[i]);
                }
                else continue;
            }
            return odds.Sum();
        }

        // Sum integer array for large numbers
        public static decimal LargeIntSummer(int[] array)
        {
            List<decimal> largerNumbers = new List<decimal>();
            for (int x = 0; x < array.Length; x++)
            {
                decimal converted = Convert.ToDecimal(array[x]);
                largerNumbers.Add(converted);
            }
            decimal largeSum = largerNumbers.Sum();
            return largeSum;
        }

        // String Reverser
        public static string StringReverser(string str)
        {
            string reverseString = null;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverseString += str[i];
            }
            return reverseString;
        }

        // Remove repeated characters in string
        public static string RepeatRemover(string str)
        {
            List<char> nonRepeats = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                bool isRepeat = false;
                foreach (char character in nonRepeats)
                {
                    if (str[i] == character)
                        {
                            isRepeat = true;
                            break;
                        }
                }
                if (!isRepeat) nonRepeats.Add(str[i]);
            }
            StringBuilder sb = new StringBuilder();
            foreach (char character in nonRepeats)
            {
                sb.Append(character.ToString());
            }
            string repeatsRemoved = sb.ToString();
            return repeatsRemoved;
        }

        //FizzBuzz!
        public static void FizzBuzz()
        {
            for (int i = 1; i < 101; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0) Console.WriteLine("Fizz");
                else if (i % 5 == 0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
