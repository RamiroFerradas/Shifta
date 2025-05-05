namespace NotificationsApp.Notifications
{
    public class PushNotification : NotificationBase
    {
        public PushNotification(string deviceId) : base(deviceId) { }

        public override void Send(string message)
        {
            Console.WriteLine($"🔔 Enviando notificación push a {Recipient}: {message}");
        }
    }
}
