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

            /*
            try
            {
                _emailService.Send(email);
            }
            catch (NotImplementedException e)
            {
                throw new MailServerException();
            }
            catch (CustomApplicationException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e);
            }             
             */
        }
    }
}
