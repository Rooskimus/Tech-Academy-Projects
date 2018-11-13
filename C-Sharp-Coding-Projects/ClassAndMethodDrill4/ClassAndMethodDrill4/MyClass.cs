using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndMethodDrill4
{
    class MyClass
    {
        public int MyMethod(int x, int y = 0)
        {
            int z = (x * x) + (y * y);
            return z;
        }
    }
}
