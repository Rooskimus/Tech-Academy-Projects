using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDrill01
{
    class Program
    {
        static void Main(string[] args)
        {
            IQuittable quitter = new Employee() { FirstName = "Wayne", LastName = "Carr" };
            quitter.Quit();
        }
    }
}
