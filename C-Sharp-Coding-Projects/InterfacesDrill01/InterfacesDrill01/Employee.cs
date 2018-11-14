using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDrill01
{
    public class Employee : Person, IQuittable
    {
        public override void SayName()
        {
            Console.WriteLine("{0} {1}", FirstName, LastName);
            Console.ReadLine();
        }

        public void Quit()
        {
            Console.WriteLine("My name is {0} {1}.  Why are you laughing?  You guys are so immature!  I quit!", FirstName, LastName);
            Console.ReadLine();
        }
    }
}
