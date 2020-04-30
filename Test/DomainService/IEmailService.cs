using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public interface IEmailService
    {
        bool Send(Email email);
    }
}
