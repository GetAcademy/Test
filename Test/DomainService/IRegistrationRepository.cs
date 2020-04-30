using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public interface IRegistrationRepository
    {
        // CRUD - Create Read Update Delete
        int Create(Registration registration);
        Registration Read(string email);
    }
}
