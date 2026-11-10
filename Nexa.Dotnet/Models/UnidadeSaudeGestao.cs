namespace Nexa.Dotnet.Models;

public class UnidadeSaudeGestao
{
    public int Id { get; set; }
    public string NomeUnidade { get; set; } = string.Empty;
    public string CodigoCnes { get; set; } = string.Empty;
    public bool Ativa { get; set; } = true;
    public Endereco Endereco { get; set; } = new();
    public ICollection<ConfiguracaoOperacional> Configuracoes { get; set; } = new List<ConfiguracaoOperacional>();

    public UnidadeSaudeGestao()
    {
    }
}
