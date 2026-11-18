using Nexa.Dotnet.Enum;

namespace Nexa.Dotnet.DTOs;

public class ConfiguracaoOperacionalResponse
{
    public int Id { get; set; }
    public int UnidadeSaudeId { get; set; }
    public int DiaSemana { get; set; }
    public DiaDaSemana DiaSemanaDescricao { get; set; }
    public string HoraAbertura { get; set; } = string.Empty;
    public string HoraFechamento { get; set; } = string.Empty;
    public int CapacidadeDiaria { get; set; }
    public int TempoMedioAtendimentoMinutos { get; set; }
    public bool ConfiguracaoAtiva { get; set; }
}
