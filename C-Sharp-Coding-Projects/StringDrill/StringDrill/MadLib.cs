using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDrill
{
    class MadLib
    {
        static void Main()
        {
            Console.WriteLine("Let's do some Mad Libs!");
            Console.WriteLine("Enter an adjective: ");
            string adjective = Console.ReadLine();
            Console.WriteLine("Enter an adverb: ");
            string adverb = Console.ReadLine();
            Console.WriteLine("Enter a singular noun: ");
            string noun = Console.ReadLine();
            Console.WriteLine("Enter a plural noun: ");
            string nounTwo = Console.ReadLine();
            Console.WriteLine("\nOnce there was a " + adjective + " " + noun + " which liked to " + adverb + " eat " + nounTwo + ".");
            Console.ReadLine();
            StringBuilder pgrph = new StringBuilder();
            pgrph.Append("But one day the " + nounTwo + " got the better of the " + adjective + " " + noun + ".");
            pgrph.Append("  They did this by " + adverb + " eating themselves instead.");
            pgrph.Append("  This confused the " + adjective + " " + noun + " to no end.");
            pgrph.Append("  In fact, the " + adjective + " " + noun + " became so confused it " + adverb.ToUpper() + " ate itself!");
            Console.WriteLine(pgrph);
            Console.Read();
        }
    }
}
