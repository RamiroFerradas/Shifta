namespace NotificationsApp.Notifications
{
    public class SmsNotification : NotificationBase
    {
        public SmsNotification(string phoneNumber) : base(phoneNumber) { }

        public override void Send(string message)
        {
            Console.WriteLine($"📱 Enviando SMS a {Recipient}: {message}...");
        }
    }
}
