using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class FraudException : Exception
    {
        public FraudException()
            : base() { }  //this constructor simply inherits the properties of the Exception class constructor.

        public FraudException(string message)
            : base(message) { }


    }
}
