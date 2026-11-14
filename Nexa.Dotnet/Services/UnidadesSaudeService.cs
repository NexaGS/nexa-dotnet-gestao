using Microsoft.EntityFrameworkCore;
using Nexa.Dotnet.Data;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;

namespace Nexa.Dotnet.Services;

public class UnidadesSaudeService
{
	private readonly NexaDbContext _nexaDbContext;
	public UnidadesSaudeService(NexaDbContext nexaDbContext)
	{
		_nexaDbContext = nexaDbContext;
	}

    public UnidadeSaudeGestao? BuscarPorId(int id)
    {
        var listaUnidades = ListarUnidadesAsync();
        return listaUnidades.FirstOrDefault(p => p.Id == id);
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
        await SalvarAlteracoes();

        return unidade;
    }

    public async Task<UnidadeSaudeGestao?> AtualizarUnidadeAsync(int id)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }


        _nexaDbContext.UnidadesSaude.Update(unidade);
        await SalvarAlteracoes();

        return unidade;
    }

    public async Task<UnidadeSaudeGestao?> ExcluirUnidadeAsync(int id)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }


        _nexaDbContext.UnidadesSaude.Remove(unidade);
        await SalvarAlteracoes();

        return unidade;
    }

    private Task SalvarAlteracoes() => _nexaDbContext.SaveChangesAsync();
}
