using System.ComponentModel.DataAnnotations;

namespace Nexa.Dotnet.DTOs;

public class AtualizarConfiguracaoRequest
{
    [Required(ErrorMessage = "O dia da semana é obrigatório.")]
    [Range(0, 6, ErrorMessage = "Dia da semana deve ser entre 0 (Domingo) e 6 (Sábado).")]
    public DayOfWeek DiaSemana { get; set; }

    [Required(ErrorMessage = "A hora de abertura é obrigatória.")]
    public TimeOnly HoraAbertura { get; set; }

    [Required(ErrorMessage = "A hora de fechamento é obrigatória.")]
    public TimeOnly HoraFechamento { get; set; }

    [Required(ErrorMessage = "A capacidade diária é obrigatória.")]
    [Range(1, 10000, ErrorMessage = "A capacidade diária deve ser maior que zero.")]
    public int CapacidadeDiaria { get; set; }

    [Required(ErrorMessage = "O tempo médio de atendimento é obrigatório.")]
    [Range(1, 480, ErrorMessage = "O tempo médio de atendimento deve ser de pelo menos 1 minuto.")]
    public int TempoMedioAtendimentoMinutos { get; set; }

    public bool ConfiguracaoAtiva { get; set; }
}
