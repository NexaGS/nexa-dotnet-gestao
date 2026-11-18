using Microsoft.EntityFrameworkCore;
using Nexa.Dotnet.Data;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Mapper;
using Nexa.Dotnet.Models;
using Nexa.Dotnet.Notifications;

namespace Nexa.Dotnet.Services;

public class UnidadesSaudeService
{
	private readonly NexaDbContext _nexaDbContext;
    private readonly NotificationContext _notificationContext;
	public UnidadesSaudeService(NexaDbContext nexaDbContext, NotificationContext notificationContext)
	{
		_nexaDbContext = nexaDbContext;
        _notificationContext = notificationContext;
	}

    public UnidadeSaudeGestao? BuscarPorId(int id)
    {
        return _nexaDbContext.UnidadesSaude.Include(u => u.Configuracoes).FirstOrDefault(u => u.Id == id);
    }

    public ICollection<UnidadeDetalhesResponse> ListarUnidadesAsync()
	{
		return _nexaDbContext.UnidadesSaude
            .Include(u => u.Configuracoes)
            .AsEnumerable()
            .Select(u => UnidadeSaudeMapper.MapearParaResponse(u)).ToList();
	}

    public UnidadeDetalhesResponse? BuscarUnidadeSaudeAsync(int id)
    {
        return BuscarPorId(id) != null ? UnidadeSaudeMapper.MapearParaResponse(BuscarPorId(id)) : null;
	}


    public async Task<UnidadeDetalhesResponse> CriarUnidadeAsync(CriarUnidadeRequest request)
    {
        var unidade = new UnidadeSaudeGestao
        {
            NomeUnidade = request.NomeUnidade,
            CodigoCnes = request.CodigoCnes,
            Ativa = request.Ativa,
            Endereco = new Endereco
            {
                Logradouro = request.Endereco.Logradouro,
                Numero = request.Endereco.Numero,
                Complemento = request.Endereco.Complemento,
                Bairro = request.Endereco.Bairro,
                Cidade = request.Endereco.Cidade,
                Estado = request.Endereco.Estado,
                Cep = request.Endereco.Cep
            }
        };
        

        _nexaDbContext.UnidadesSaude.AddAsync(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return UnidadeSaudeMapper.MapearParaResponse(unidade);
    }

    public async Task<UnidadeDetalhesResponse?> AtualizarNomeUnidadeAsync(int id, string nome)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }

        unidade.NomeUnidade = nome;


        _nexaDbContext.UnidadesSaude.Update(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return UnidadeSaudeMapper.MapearParaResponse(unidade);
    }

    public async Task<UnidadeDetalhesResponse?> TornarStatusAtivoUnidadeAsync(int id)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }

        if (unidade.Ativa == true)
        {
            _notificationContext.AddNotification("Unidade de saúde já está ativa!");
            return null;
        }

        unidade.Ativa = true;

        _nexaDbContext.UnidadesSaude.Update(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return UnidadeSaudeMapper.MapearParaResponse(unidade);
    }
    public async Task<UnidadeDetalhesResponse?> TornarStatusInativoUnidadeAsync(int id)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }

        if(unidade.Ativa == false)
        {
            _notificationContext.AddNotification("Unidade de saúde já está inativa!");
            return null;
        }


        unidade.Ativa = false;

        _nexaDbContext.UnidadesSaude.Update(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return UnidadeSaudeMapper.MapearParaResponse(unidade); ;
    }

    public async Task<UnidadeDetalhesResponse?> AtualizarEnderecoUnidadeAsync(int id, EnderecoDto request)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }


        unidade.Endereco.Logradouro = request.Logradouro;
        unidade.Endereco.Numero = request.Numero;
        unidade.Endereco.Complemento = request.Complemento;
        unidade.Endereco.Bairro = request.Bairro;
        unidade.Endereco.Cidade = request.Cidade;
        unidade.Endereco.Estado = request.Estado;
        unidade.Endereco.Cep = request.Cep;


        _nexaDbContext.UnidadesSaude.Update(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return UnidadeSaudeMapper.MapearParaResponse(unidade);
    }

    public async Task<bool> ExcluirUnidadeAsync(int id)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return false;
        }

        _nexaDbContext.UnidadesSaude.Remove(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return true;
    }

}
