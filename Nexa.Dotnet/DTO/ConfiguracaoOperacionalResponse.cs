namespace Nexa.Dotnet.DTOs;

public class ConfiguracaoOperacionalResponse
{
    public int Id { get; set; }
    public int UnidadeSaudeId { get; set; }
    public DayOfWeek DiaSemana { get; set; }
    public string DiaSemanaDescricao { get; set; } = string.Empty;
    public string HoraAbertura { get; set; } = string.Empty;
    public string HoraFechamento { get; set; } = string.Empty;
    public int CapacidadeDiaria { get; set; }
    public int TempoMedioAtendimentoMinutos { get; set; }
    public bool ConfiguracaoAtiva { get; set; }
}
