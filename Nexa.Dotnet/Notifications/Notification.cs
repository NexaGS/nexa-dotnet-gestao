namespace Nexa.Dotnet.Notifications;

public class Notification
{
    public string Mensagem { get; set; } = string.Empty;

    public Notification(string mensagem)
    {
        Mensagem = mensagem;
    }

    public class NotificationContext
    {
        private readonly List<Notification> _notifications = new();

        public IReadOnlyCollection<Notification> notifications => _notifications.AsReadOnly();
        public bool HasNotifications => _notifications.Any();

        public void AddNotification(string mensagem) {
            _notifications.Add(new Notification(mensagem));
        }
    }
}
