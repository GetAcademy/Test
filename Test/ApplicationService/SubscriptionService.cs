using System;
using System.Collections.Generic;
using System.Text;
using Test.Exceptions;

namespace Test
{
    public class SubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly IRegistrationRepository _registrationRepository;

        public SubscriptionService(IEmailService emailService, IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            _emailService = emailService;
        }

        public void Subscribe(string emailAddress)
        {
            var registration = new Registration(emailAddress);
            var rowsAffected = _registrationRepository.Create(registration);
            if (rowsAffected == 0) return;
            var email = new ConfirmationEmail(emailAddress, registration.VerificationCode);
            _emailService.Send(email);
        }
    }
}
