namespace Nexa.Dotnet.DTOs;

public class UnidadeDetalhesResponse
{
    public int Id { get; set; }
    public string NomeUnidade { get; set; } = string.Empty;
    public string CodigoCnes { get; set; } = string.Empty;
    public bool Ativa { get; set; }
    public EnderecoDto Endereco { get; set; } = new();
    public List<ConfiguracaoOperacionalResponse> Configuracoes { get; set; } = new();
}
