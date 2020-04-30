using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Exceptions
{
    public class UnknownErrorException : CustomApplicationException
    {
        public UnknownErrorException(Exception innerException)
            : base("", innerException)
        {

        }
    }
}
