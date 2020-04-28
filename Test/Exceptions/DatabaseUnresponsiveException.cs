using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Exceptions
{
    class DatabaseUnresponsiveException : CustomApplicationException
    {
        public DatabaseUnresponsiveException(Exception innerException)
        : base("", innerException)
        {

        }
    }
}
