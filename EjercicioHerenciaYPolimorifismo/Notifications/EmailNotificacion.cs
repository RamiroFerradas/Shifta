namespace NotificationsApp.Notifications
{
    public class EmailNotification : NotificationBase
    {
        public EmailNotification(string email) : base(email) { }

        public override void Send(string message)
        {
            Console.WriteLine($"📧 Enviando correo electrónico a {Recipient}: {message}...");
        }
    }
}
