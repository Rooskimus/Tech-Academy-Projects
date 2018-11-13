using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndMethodDrill3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMath numbers = new MyMath();
            int resultOne = numbers.MyMethodOne(33);
            int resultTwo = numbers.MyMethodOne(9.23402100m);
            int resultThree = numbers.MyMethodOne("7");

            Console.WriteLine("Result 1: {0}\nResult 2: {1}\nResult 3: {2}", resultOne, resultTwo, resultThree);
            Console.Read();
        }
    }
}
