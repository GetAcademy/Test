using System;
using Moq;
using NUnit.Framework;
using Test.Exceptions;

namespace Test.Test
{
    public class Tests
    {
        [Test]
        public void TestAllOk()
        {
            var emailService = new DummyEmailService();
            var registrationRepository = new DummyRegistrationRepository();
            var service = new SubscriptionService(emailService, registrationRepository);
            service.Subscribe("terje@kolderup.net");
            Assert.IsTrue(emailService.SendHasBeenCalled);
            Assert.IsTrue(registrationRepository.CreateHasBeenCalled);
        }

        [Test]
        public void TestDbFails()
        {
            var emailService = new DummyEmailService();
            var registrationRepository = new DummyRegistrationRepository(true);
            var service = new SubscriptionService(emailService, registrationRepository);
            Assert.Throws<DatabaseUnresponsiveException>(() => service.Subscribe("terje@kolderup.net"));
            Assert.IsTrue(registrationRepository.CreateHasBeenCalled);
            Assert.IsFalse(emailService.SendHasBeenCalled);
        }

        [Test]
        public void TestAllOk2()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var registrationRepositoryMock = new Mock<IRegistrationRepository>();
            registrationRepositoryMock
                .Setup(d => d.Create(It.IsAny<Registration>()))
                .Returns(1);
            var service = new SubscriptionService(emailServiceMock.Object, registrationRepositoryMock.Object);
            service.Subscribe("terje@kolderup.net");
            emailServiceMock.Verify(s=>s.Send(It.IsAny<Email>()));
            registrationRepositoryMock.Verify(d=>d.Create(It.IsAny<Registration>()));
        }

        [Test]
        public void TestDbFails2()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var registrationRepositoryMock = new Mock<IRegistrationRepository>();
            registrationRepositoryMock
                .Setup(d => d.Create(It.IsAny<Registration>()))
                .Returns(0);
            var service = new SubscriptionService(emailServiceMock.Object, registrationRepositoryMock.Object);
            service.Subscribe("terje@kolderup.net");
            //emailServiceMock.Verify(s => s.Send(It.IsAny<Email>()));
            emailServiceMock.VerifyNoOtherCalls();
            registrationRepositoryMock.Verify(d => d.Create(It.IsAny<Registration>()));
        }
    }

    class DummyEmailService : IEmailService
    {
        public bool SendHasBeenCalled { get; private set; } = false;
        public bool Send(Email email)
        {
            SendHasBeenCalled = true;
            return true;
        }
    }

    class DummyRegistrationRepository : IRegistrationRepository
    {
        private bool _shouldFail;

        public DummyRegistrationRepository(bool shouldFail = false)
        {
            _shouldFail = shouldFail;
        }
        public bool CreateHasBeenCalled { get; private set; } = false;
        public int Create(Registration registration)
        {
            CreateHasBeenCalled = true;
            if (_shouldFail) throw new DatabaseUnresponsiveException();
            return 1;
        }

        public Registration Read(string email)
        {
            return new Registration("knut@mail.com");
        }
    }
}