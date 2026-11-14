using Nexa.Dotnet.Data;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;
using static Nexa.Dotnet.Notifications.Notification;

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

        if (unidadeSaude == null)
        {
            _notificationContext.AddNotification("Unidade de saúde não encontrada");
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

        if (_notificationContext.HasNotifications)
        {
            return null;
        }

        _nexaDbContext.ConfiguracoesOperacionais.AddAsync(configuracao);
        await _nexaDbContext.SalvarAlteracoes();

        return configuracao;
    }
}
