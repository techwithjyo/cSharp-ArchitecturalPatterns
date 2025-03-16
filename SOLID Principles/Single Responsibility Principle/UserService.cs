using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles.Single_Responsibility_Principle
{
    //Earlier code
    public class UserService
    {
        public void RegisterUser(string userName, string password)
        {
            Console.WriteLine("User Registered Successfully!!");

            SendWelcomeEmail();
        }

        private void SendWelcomeEmail()
        {
            Console.WriteLine("Welcome Email sent successfully!!");
        }
    }

    //Defination: The "S" in SOLID stands for the Single Responsibility Principle (SRP).
    //This principle states that a class should have only one reason to change,
    //meaning it should have only one job or responsibility.

    //In the above example, the UserService class has two responsibilities:
    //Registering a user.
    //Sending a welcome email

    //Following SRP
    //UserService: Handles user registration.
    //EmailService: Handles sending emails.

    //-------------------Modified code-------------------------

    public class NewUserService
    {
        private readonly EmailService _emailService;
        public NewUserService(EmailService emailService)
        {
            _emailService = emailService;
        }
        public void RegisterUser(string userName, string password)
        {
            Console.WriteLine("User Registered Successfully!!");

            _emailService.SendWelcomeEmail();
        }

    }

    public class EmailService
    {
        public void SendWelcomeEmail()
        {
            Console.WriteLine("Welcome Email sent successfully!!");
        }
    }

}
