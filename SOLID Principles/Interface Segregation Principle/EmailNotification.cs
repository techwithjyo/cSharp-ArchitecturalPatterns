using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static SOLID_Principles.Interface_Segregation_Principle.EmailNotification;

namespace SOLID_Principles.Interface_Segregation_Principle
{
    public class EmailNotification
    {
        //----------------------Old Code---------------------
        public interface IEmailService
        {
            void SendWelcomeEmail();
            void SendPasswordResetEmail();
            void SendPromotionalEmail();
        }

        public class WelcomeServiceEmail : IEmailService
        {
            public void SendPasswordResetEmail()
            {
                throw new NotImplementedException();
            }

            public void SendPromotionalEmail()
            {
                throw new NotImplementedException();
            }

            public void SendWelcomeEmail()
            {
                Console.WriteLine("Welcome Email!!");
            }
        }
        public class PasswordResetEmail : IEmailService
        {
            public void SendPasswordResetEmail()
            {
                Console.WriteLine("Password reset email!!");
            }

            public void SendPromotionalEmail()
            {
                throw new NotImplementedException();
            }

            public void SendWelcomeEmail()
            {
                throw new NotImplementedException();
            }
        }
    }

    //The "I" in SOLID stands for the Interface Segregation Principle(ISP). 
    //    This principle states that no client should be forced to depend on methods it does not use.
    //    In other words, 
    //    it's better to have many small, specific interfaces than a single, large, general-purpose interface.


    //We have a single interface IEmailService that includes methods for sending all types of emails.
    //This forces all email services to implement methods they do not need.

    //---------------Modified Code----------------

    public class NewEmailNotification
    {
        public interface IWelcomeEmailService
        {
            void SendWelcomeEmail();
        }
        public interface IPasswordResetService
        {
            void SendPasswordResetEmail();
        }
        public interface IPromotionalEmailService
        {
            void SendPromotionalEmail();
        }

        public class WelcomeServiceEmail : IWelcomeEmailService

        {
            public void SendWelcomeEmail()
            {
                Console.WriteLine("Welcome email!!");
            }
        }
        public class PasswordResetEmail : IPasswordResetService
        {
            public void SendPasswordResetEmail()
            {
                Console.WriteLine("Password reset email!!");
            }
        }

    }
}
