using System;
using System.Collections.Generic;
using System.Text;
using Test.Exceptions;

namespace Test
{
    class SubscriptionService
    {
        private IEmailService _emailService;
        private IRegistrationRepository _registrationRepository;

        public SubscriptionService(IEmailService emailService, IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            _emailService = emailService;
        }

        public void Subscribe(string emailAddress)
        {
            var registration = new Registration(emailAddress);
            try
            {
                var isSaved = _registrationRepository.Create(registration);
            }
            catch (NotImplementedException e)
            {
                throw new DatabaseUnresponsiveException(e);
            }
            catch (Exception e)
            {
                throw  new UnknownErrorException(e);
            }

            var email = new ConfirmationEmail(emailAddress, registration.VerificationCode);
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
        }
    }
}
