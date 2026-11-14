namespace Nexa.Dotnet.Notifications;

public class NotificationContext
{
    private readonly List<Notification> _notifications = new();

    public IReadOnlyCollection<Notification> notifications => _notifications.AsReadOnly();
    public bool HasNotifications => _notifications.Any();

    public void AddNotification(string mensagem)
    {
        _notifications.Add(new Notification(mensagem));
    }
}
