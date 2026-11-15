using Nexa.Dotnet.Data;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;
using Nexa.Dotnet.Notifications;

namespace Nexa.Dotnet.Services;

public class ConfiguracaoOperacionalService
{
    private readonly NexaDbContext _nexaDbContext;
    private readonly UnidadesSaudeService _unidadesSaudeService;
    private readonly NotificationContext _notificationContext;


    public ConfiguracaoOperacionalService(NexaDbContext nexaDbContext, UnidadesSaudeService unidadesSaudeService, NotificationContext notificationContext)
    {
        _nexaDbContext = nexaDbContext;
        _unidadesSaudeService = unidadesSaudeService;
        _notificationContext = notificationContext;
    }

    public ICollection<ConfiguracaoOperacional> ListarConfiguracoesUnidadeAsync(int unidadeSaudeId)
    {
        return _nexaDbContext.ConfiguracoesOperacionais.Where(config => config.UnidadeSaudeId == unidadeSaudeId).ToList();
    }

    public async Task<ConfiguracaoOperacional?> CriarConfiguracaoAsync(CriarConfiguracaoRequest request)
    {
        var unidadeSaude = _unidadesSaudeService.BuscarPorId(request.UnidadeSaudeId);

        if(request.HoraAbertura >= request.HoraFechamento)
        {
            _notificationContext.AddNotification("Hora da abertura deve ser anterior a hora de fechamento.");
        }

        if (request.CapacidadeDiaria <= 0)
        {
            _notificationContext.AddNotification("Capacidade diária da unidade deve ser maior que 0.");
        }

        if (_notificationContext.HasNotifications)
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
        await _nexaDbContext.SalvarAlteracoes();

        return configuracao;
    }

    public ConfiguracaoOperacional? BuscarPorId(int id) { 
        return _nexaDbContext.ConfiguracoesOperacionais.FirstOrDefault(c => c.Id == id);
    }

    public async Task<ConfiguracaoOperacional?> AtualizarConfiguracaoAsync(int id, AtualizarConfiguracaoRequest request)
    {
        var config = BuscarPorId(id);

        if (config == null)
        {
            return null;
        }

        if (request.HoraAbertura >= request.HoraFechamento)
        {
            _notificationContext.AddNotification("Hora da abertura deve ser anterior a hora de fechamento.");
        }

        if (request.CapacidadeDiaria <= 0)
        {
            _notificationContext.AddNotification("Capacidade diária da unidade deve ser maior que 0.");
        }

        if (_notificationContext.HasNotifications)
        {
            return null;
        }

        config.DiaSemana = request.DiaSemana;
        config.HoraAbertura = request.HoraAbertura;
        config.HoraFechamento = request.HoraFechamento;
        config.CapacidadeDiaria = request.CapacidadeDiaria;
        config.TempoMedioAtendimentoMinutos = request.TempoMedioAtendimentoMinutos;
        config.ConfiguracaoAtiva = request.ConfiguracaoAtiva;

        _nexaDbContext.ConfiguracoesOperacionais.Update(config);
        await _nexaDbContext.SalvarAlteracoes();

        return config;
    }
    public async Task<bool> ExcluirConfiguracaoAsync(int id)
    {
        var configuracao = BuscarPorId(id);

        if(configuracao == null)
        {
            return false;
        }

        _nexaDbContext.ConfiguracoesOperacionais.Remove(configuracao);
        await _nexaDbContext.SalvarAlteracoes();

        return true;
    }
}
