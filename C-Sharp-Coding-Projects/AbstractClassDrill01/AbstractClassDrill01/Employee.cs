using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDrill01
{
    public class Employee : Person
    {
        public override void SayName()
        {
            Console.WriteLine("{0} {1}", FirstName, LastName);
            Console.ReadLine();
        }
    }
}
