using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Exceptions
{
    public class DatabaseUnresponsiveException : CustomApplicationException
    {
        public DatabaseUnresponsiveException()
        {
        }

        public DatabaseUnresponsiveException(Exception innerException)
        : base("", innerException)
        {

        }
    }
}
