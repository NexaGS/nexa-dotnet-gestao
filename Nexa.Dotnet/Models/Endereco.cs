using Microsoft.EntityFrameworkCore;

namespace Nexa.Dotnet.Models;

[Owned]
public class Endereco
{
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string? Complemento { get; set; }
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty; // Sigla UF (ex: "SP")
    public string Cep { get; set; } = string.Empty;
}
