using System;
using Test.Exceptions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new SubscriptionService(new EmailService(), new RegistrationRepository());
            try
            {
                service.Subscribe("terjekolderup.net");
            }
            catch (DatabaseUnresponsiveException)
            {
                Console.WriteLine("Lagringen i databasen feilet. Prøv igjen om litt. ");
            }
            catch (UnknownErrorException)
            {
                Console.WriteLine("Ukjent feil. ");
            }
        }
    }
}
