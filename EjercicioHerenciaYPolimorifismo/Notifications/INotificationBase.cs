﻿namespace NotificationsApp.Notifications
{
    public abstract class NotificationBase : INotificable
    {
        public string Recipient { get; set; }

        public NotificationBase(string recipient)
        {
            Recipient = recipient;
        }

        public virtual void Send(string message)
        {
            Console.WriteLine($"Sending message to {Recipient}: {message}...");
        }
    }
}
