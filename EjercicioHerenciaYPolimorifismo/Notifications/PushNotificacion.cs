namespace NotificationsApp.Notifications
{
    public class PushNotification : NotificationBase
    {
        public PushNotification(string deviceId) : base(deviceId) { }

        public override void Send(string message)
        {
            Console.WriteLine($"🔔 Sending push notification to {Recipient}: {message}");
        }
    }
}
