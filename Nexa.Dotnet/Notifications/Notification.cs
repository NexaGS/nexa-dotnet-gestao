namespace Nexa.Dotnet.Notifications;

public class Notification
{
    public string Mensagem { get; set; } = string.Empty;

    public Notification(string mensagem)
    {
        Mensagem = mensagem;
    }
}
