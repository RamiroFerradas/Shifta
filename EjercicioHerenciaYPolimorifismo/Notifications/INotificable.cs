namespace NotificationsApp.Notifications
{
    public interface INotificable
    {
        string Recipient { get; } 
        void Send(string message);
    }
}
