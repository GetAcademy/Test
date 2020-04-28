using System;
using System.Collections.Generic;
using System.Text;
using Test.Exceptions;

namespace Test
{
    class EmailService : IEmailService
    {
        public bool Send(Email email)
        {
            throw new InvalidEmailAddressException();
        }
    }
}
