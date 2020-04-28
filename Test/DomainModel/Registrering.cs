using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Registration
    {
        public string Email { get; set; }
        public Guid VerificationCode { get; set; }

        public Registration(string email, Guid verificationCode)
        {
            Email = email;
            VerificationCode = verificationCode;
        }

        public Registration(string email) : this(email, Guid.NewGuid())
        {
        }
    }
}
