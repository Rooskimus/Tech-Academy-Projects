using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDrill01
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number() { Amount = 100.7m };
            Console.WriteLine(number.Amount);
            Console.ReadLine();
        }
    }
}
