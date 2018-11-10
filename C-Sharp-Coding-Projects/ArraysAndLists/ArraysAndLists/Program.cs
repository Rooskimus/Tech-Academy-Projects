using System;
using System.Collections.Generic;

namespace ArraysAndLists
{
    class Program
    {
        static void Main()
        {
            // Arrays: used for things with FIXED quantities as the length is always SET.
            int[] numArray = new int[5]; // Declares an array with the name numArray containing integers with a length of 5.
            numArray[0] = 5;
            numArray[1] = 2;
            numArray[2] = 10;
            numArray[3] = 200;
            numArray[4] = 5000;

            int[] numArray1 = new int[] { 5, 2, 10, 200, 5000 }; // Shorthand way to assign values.  
            // You may enter any number of values without setting the number beforehand.
            // However, once the length is set it is fixed!

            int[] numArray2 = { 5, 2, 10, 200, 5000, 600, 2300 }; // Even shorter shorthand.

            numArray2[5] = 650;

            Console.WriteLine(numArray2[5] + "\n");


            // Lists: used for things with variable quantities as length is flued; arrays can be better for large amounts of data though.
            List<int> intList = new List<int>(); // Declares and instantiates a list named intList.
            intList.Add(4);  // adds 4 to index 0
            intList.Add(10); // adds 10 to index 1
            intList.Remove(4); // removes 4 from index 0 and automatically reduces size of list so that 10 is now index 0.

            Console.WriteLine(intList[0]);
            Console.ReadLine();
        }
    }
}
