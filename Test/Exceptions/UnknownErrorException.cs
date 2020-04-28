using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Exceptions
{
    class UnknownErrorException : CustomApplicationException
    {
        public UnknownErrorException(Exception innerException)
            : base("", innerException)
        {

        }
    }
}
