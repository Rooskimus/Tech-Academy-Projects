using System;
using System.Text;

namespace AboutStrings
{
    class AboutStrings
    {
        static void Main()
        {
            Console.WriteLine("The man said \"Hello.\""); // Backslash is an "escape character" which allows you to "escape" the standard formatting of a string.
            Console.WriteLine("This will have \na line break."); // \n is the line break.  Notice the backslash affects only characters immediately after it.
            Console.WriteLine("\tThis line has been tabbed."); // \t is for tab.
            Console.WriteLine("To display \\ you have to type \"\\\\\""); // \\ is the escape character followed by a backsplash you'd like to display.
            Console.WriteLine(@"Everything\inside\should\display\including\backslashes\"); // the @ in front of quotation marks allows \ to not be the escape character.
            Console.WriteLine("But using the @ symbol as in the previous line you cannot display a \\ and a \" because the backslash doesn't count as an escape character.");

            // Some convenient ways to manipulate or use strings:
            string name = "Andrew";
            Console.WriteLine(name);
            bool trueOrFalse = name.Contains("s");
            bool endsWithW = name.EndsWith("w");
            Console.WriteLine("Does " + name + " contain an S? " + trueOrFalse);
            Console.WriteLine("Does " + name + " end with a W? " + endsWithW);

            int length = name.Length;
            Console.WriteLine(name + " has " + length + " characters.");
            Console.WriteLine(name.ToUpper());
            Console.WriteLine(name.ToLower());

            //  Strings are immutable, which means that every time you change a string, you're actually simply creating a new string.
            //  The issue is this will leave the old string in your memory.  Not a big deal on small projects, but when strings that 
            //  are being modified number in the thousands, you start to run very low on memory and things slow to a crawl.
            //  Enter StringBuilder, a dynamic object created to have expandable strings while using the same memory.

            StringBuilder myName = new StringBuilder();

            myName.Append("My name is Andrew");
            Console.WriteLine(myName);
            myName.Append(" and I'm testing appending.");
            Console.WriteLine(myName);
            myName.Remove(18, 26); // The 18 says where to start removing, the 26 says how many characters to remove.
            Console.WriteLine(myName);

            Console.Read();
        }
    }
}
