using Nexa.Dotnet.Data;
using Nexa.Dotnet.DTOs;
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
        var listaUnidades = ListarUnidadesAsync();
        return listaUnidades.FirstOrDefault(u => u.Id == id);
    }

    public ICollection<UnidadeSaudeGestao> ListarUnidadesAsync()
	{
		return _nexaDbContext.UnidadesSaude.ToList();
	}

    public UnidadeSaudeGestao? BuscarUnidadeSaudeAsync(int id)
    {
        return BuscarPorId(id) != null ? BuscarPorId(id) : null;
	}



    public async Task<UnidadeSaudeGestao> CriarUnidadeAsync(CriarUnidadeRequest request)
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

        return unidade;
    }

    public async Task<UnidadeSaudeGestao?> AtualizarNomeUnidadeAsync(int id, string nome)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }

        unidade.NomeUnidade = nome;


        _nexaDbContext.UnidadesSaude.Update(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return unidade;
    }

    public async Task<UnidadeSaudeGestao?> TornarStatusAtivoUnidadeAsync(int id)
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

        return unidade;
    }
    public async Task<UnidadeSaudeGestao?> TornarStatusInativoUnidadeAsync(int id)
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

        return unidade;
    }

    public async Task<UnidadeSaudeGestao?> AtualizarEnderecoUnidadeAsync(int id, EnderecoDto request)
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

        return unidade;
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
