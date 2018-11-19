using System;
using System.IO;

namespace LogTextFileDrill
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a number to log to the file: ");
            string number = Console.ReadLine();
            string strPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory); // This gets the desktop directory of the machine running the program.
            File.WriteAllText(strPath + "\\log.txt", number); // I'm appending the name of the file to create on the desktop.
            string readNumber = File.ReadAllText(strPath + "\\log.txt"); // Then reading that same file.
            Console.WriteLine("The number you logged as is being read from the log created is: " + readNumber);
            Console.ReadLine();
        }
    }
}
