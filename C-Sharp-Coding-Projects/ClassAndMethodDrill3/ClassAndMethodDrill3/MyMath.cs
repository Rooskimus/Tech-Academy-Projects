using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndMethodDrill3
{
    class MyMath
    {
        public int MyMethodOne(int x)
        {
            x = x * x;
            return x;
        }

        public int MyMethodOne(decimal x)
        {
            x = x + 21;
            return (int)x;
        }

        public int MyMethodOne(string x)
        {
            int y = int.Parse(x);
            y = y * 2;
            return y;
        }

    }
}
