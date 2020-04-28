using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    interface IRegistrationRepository
    {
        // CRUD - Create Read Update Delete
        bool Create(Registration registration);
        Registration Read(string email);
    }
}
