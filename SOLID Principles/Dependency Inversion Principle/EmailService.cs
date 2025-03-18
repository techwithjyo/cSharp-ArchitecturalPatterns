using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles.Dependency_Inversion_Principle
{
    //The "D" in SOLID stands for the Dependency Inversion Principle (DIP).
    //This principle states that high-level modules should not depend on low-level modules.
    //Both should depend on abstractions (e.g., interfaces or abstract classes). 

    //--------------------------Old Code--------------------------
    public class EmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine("Sneding email!!");
        }
    }
    public class SmsService
    {
        public void SendSms(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }
    public class NotificationService
    {
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;

        public NotificationService()
        {
            _emailService = new EmailService(); // new keyword means tight coupling
            _smsService = new SmsService();
        }

        public void SendNotification(string message)
        {
            _emailService.SendEmail(message);
            _smsService.SendSms(message);
        }
    }

    //In the above example,
    //the NotificationService class depends directly on the EmailService and SmsService classes,
    //violating the Dependency Inversion Principle.

    //-----------------------------New Code----------------------------------

    public interface INotificationChannel
    {
        void Send(string message);
    }
    public class EmailServiceNew : INotificationChannel
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }

    public class SmsServiceNew : INotificationChannel
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    public class NotificationServiceNew
    {
        private readonly IEnumerable<INotificationChannel> _notificationChannels;
        public NotificationServiceNew(IEnumerable<INotificationChannel> notificationChannels)
        {
            _notificationChannels = notificationChannels;
        }

        public void SendNotifications(string message)
        {
            foreach (var channel in _notificationChannels)
            {
                channel.Send(message);
            }
        }

    }
}
