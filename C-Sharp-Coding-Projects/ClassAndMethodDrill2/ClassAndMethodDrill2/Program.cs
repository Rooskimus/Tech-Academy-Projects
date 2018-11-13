using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndMethodDrill2
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo demonstrate = new Demo();
            demonstrate.DemoMethod(3, 5);
            demonstrate.DemoMethod(x: 4, y: 6);
            Console.Read();
        }
    }
}
