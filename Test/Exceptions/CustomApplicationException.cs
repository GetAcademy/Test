using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Exceptions
{
    class CustomApplicationException : ApplicationException
    {
        public CustomApplicationException()
        {
            
        }

        public CustomApplicationException(string msg, Exception inner) : base(msg, inner)
        {
            
        }
    }
}
