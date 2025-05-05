namespace NotificationsApp.Notifications
{
    public class SlackNotification : INotificable
    {
        public string Channel { get; set; }

        public SlackNotification(string channel)
        {
            Channel = channel;
        }

        public string Recipient => $"Canal de Slack: #{Channel}";

        public void Send(string message)
        {
            Console.WriteLine($"💬 Enviando mensaje al canal de Slack #{Channel}: {message}");
        }
    }
}
