using Nexa.Dotnet.Data;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;

namespace Nexa.Dotnet.Services;

public class ConfiguracaoOperacionalService
{
    private readonly NexaDbContext _nexaDbContext;
    private readonly UnidadesSaudeService _unidadesSaudeService;

    public ConfiguracaoOperacionalService(NexaDbContext nexaDbContext, UnidadesSaudeService unidadesSaudeService)
    {
        _nexaDbContext = nexaDbContext;
        _unidadesSaudeService = unidadesSaudeService;
    }

    public ICollection<ConfiguracaoOperacional> ListarConfiguracoesUnidadeAsync(int unidadeSaudeId)
    {
        return _nexaDbContext.ConfiguracoesOperacionais.Where(config => config.UnidadeSaudeId == unidadeSaudeId).ToList();
    }

    public async Task<ConfiguracaoOperacional?> CriarConfiguracaoOperacional(CriarConfiguracaoRequest request)
    {
        var unidadeSaude = _unidadesSaudeService.BuscarPorId(request.UnidadeSaudeId);

        if(unidadeSaude == null)
        {
            return null;
        }

        var configuracao = new ConfiguracaoOperacional
        {
            UnidadeSaudeId = request.UnidadeSaudeId,
            DiaSemana = request.DiaSemana,
            HoraAbertura = request.HoraAbertura,
            HoraFechamento = request.HoraFechamento,
            CapacidadeDiaria = request.CapacidadeDiaria,
            TempoMedioAtendimentoMinutos = request.TempoMedioAtendimentoMinutos,
            ConfiguracaoAtiva = request.ConfiguracaoAtiva,
            UnidadeSaude = unidadeSaude
        };

        _nexaDbContext.ConfiguracoesOperacionais.AddAsync(configuracao);
        await SalvarAlteracoes();

        return configuracao;
    }

    private Task SalvarAlteracoes() => _nexaDbContext.SaveChangesAsync();
}
