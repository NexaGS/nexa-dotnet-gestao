namespace Nexa.Dotnet.Models;

public class ConfiguracaoOperacional
{
    public int Id { get; set; }
    public int UnidadeSaudeId { get; set; }
    public DayOfWeek DiaSemana { get; set; }
    public TimeOnly HoraAbertura { get; set; }
    public TimeOnly HoraFechamento { get; set; }
    public int CapacidadeDiaria { get; set; }
    public int TempoMedioAtendimentoMinutos { get; set; }
    public bool ConfiguracaoAtiva { get; set; } = true;
    public UnidadeSaudeGestao? UnidadeSaude { get; set; }

    public ConfiguracaoOperacional()
    {
    }
}
