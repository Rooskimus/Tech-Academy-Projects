using System;

namespace BranchingDrill
{
    class PackageExpress
    {
        static void Main()
        {
            Console.WriteLine("Wecome to Pacakge Express!  Please follow the instructions below.");
            Console.WriteLine("=================================================================="); //just entering a space
            
            // Package Weight
            Console.Write("Please enter the weight of the package in pounds: "); //using Console.Write allows input to be on the same line.
            string packageWeight = Console.ReadLine();
            float pkgWeight = EnterDigits(packageWeight);
            if (pkgWeight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express.  Good DAY, I said!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("");
            
            // Package Width
            Console.Write("Please enter the width of the package in inches: ");
            string packageWidth = Console.ReadLine();
            float pkgWidth = EnterDigits(packageWidth);
            Console.WriteLine("");
            
            // Package Height
            Console.Write("Please enter the height of the package in inches: ");
            string packageHeight = Console.ReadLine();
            float pkgHeight = EnterDigits(packageHeight);
            Console.WriteLine("");
            
            // Package Length
            Console.Write("Please enter the length of the package in inches: ");
            string packageLength = Console.ReadLine();
            float pkgLength = EnterDigits(packageLength);
            Console.WriteLine("");
            
            // Give Quote or Deny
            float pkgDimensions = pkgWidth + pkgHeight + pkgLength;
            if (pkgDimensions > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.  I said good DAY!");
            }
            else
            {
                float quote = ((pkgDimensions * pkgWeight)/100);
                Console.WriteLine("Your estimated total for this package is: " + quote.ToString("c2"));
                Console.WriteLine("");
                Console.WriteLine("Thank you for using Package Express!");
            }
            Console.ReadLine();
        }

        // I don't like leaving things open for errors based on user input, and I was typing this into each
        // dimension which wasn't very elegant so I decided to make a function for the sake of brevity.
        static float EnterDigits(string x)
        {
            float y;
            while (Single.TryParse(x, out y) == false)
            {
                Console.Write("Please enter a number using the digits 0-9 only: ");
                x = Console.ReadLine();
            }
            return y;
        }
    }
}
