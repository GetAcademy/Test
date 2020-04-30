using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class RegistrationRepository : IRegistrationRepository
    {
        public int Create(Registration registration)
        {
            throw new NotImplementedException();

            //try
            //{
            //    var isSaved = _registrationRepository.Create(registration);
            //}
            //catch (NotImplementedException e)
            //{
            //    throw new DatabaseUnresponsiveException(e);
            //}
            //catch (Exception e)
            //{
            //    throw new UnknownErrorException(e);
            //}
        }

        public Registration Read(string email)
        {
            throw new NotImplementedException();
        }
    }
}
