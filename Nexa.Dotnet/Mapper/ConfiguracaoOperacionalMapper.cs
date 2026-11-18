using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;

namespace Nexa.Dotnet.Mapper;

public static class ConfiguracaoOperacionalMapper
{
    public static ConfiguracaoOperacionalResponse MapearParaResponse(ConfiguracaoOperacional config) => new()
    {
        Id = config.Id,
        UnidadeSaudeId = config.UnidadeSaudeId,
        DiaSemana = (int) config.DiaSemana,
        DiaSemanaDescricao = config.DiaSemana,
        HoraAbertura = config.HoraAbertura.ToString("HH:mm:ss"),
        HoraFechamento = config.HoraFechamento.ToString("HH:mm:ss"),
        CapacidadeDiaria = config.CapacidadeDiaria,
        TempoMedioAtendimentoMinutos = config.TempoMedioAtendimentoMinutos,
        ConfiguracaoAtiva = config.ConfiguracaoAtiva
    };
}
