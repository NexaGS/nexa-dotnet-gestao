using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexa.Dotnet.Models;

[Table("tb_configuracao_operacional")]
public class ConfiguracaoOperacional
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("unidade_saude_id")]
    public int UnidadeSaudeId { get; set; }

    [Column("dia_semana")]
    public DayOfWeek DiaSemana { get; set; }

    [Column("hora_abertura")]
    public TimeOnly HoraAbertura { get; set; }

    [Column("hora_fechamento")]
    public TimeOnly HoraFechamento { get; set; }

    [Column("capacidade_diaria")]
    public int CapacidadeDiaria { get; set; }

    [Column("tempo_medio_minutos")]
    public int TempoMedioAtendimentoMinutos { get; set; }

    [Column("configuracao_ativa")]
    public bool ConfiguracaoAtiva { get; set; } = true;

    [ForeignKey("UnidadeSaudeId")]
    public UnidadeSaudeGestao? UnidadeSaude { get; set; }

    public ConfiguracaoOperacional()
    {
    }
}
