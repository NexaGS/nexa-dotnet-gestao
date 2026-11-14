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

    public async Task<UnidadeSaudeGestao?> AtualizarNomeUnidadeAsync(int id, AtualizarUnidadeRequest request)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }

        unidade.NomeUnidade = request.NomeUnidade;


        _nexaDbContext.UnidadesSaude.Update(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return unidade;
    }

    public async Task<UnidadeSaudeGestao?> AtualizarStatusUnidadeAsync(int id, AtualizarUnidadeRequest request)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }


        unidade.Ativa = request.Ativa;


        _nexaDbContext.UnidadesSaude.Update(unidade);
        await _nexaDbContext.SalvarAlteracoes();

        return unidade;
    }

    public async Task<UnidadeSaudeGestao?> AtualizarEnderecoUnidadeAsync(int id, AtualizarUnidadeRequest request)
    {
        var unidade = BuscarPorId(id);

        if(unidade == null)
        {
            return null;
        }


        unidade.Endereco.Logradouro = request.Endereco.Logradouro;
        unidade.Endereco.Numero = request.Endereco.Numero;
        unidade.Endereco.Complemento = request.Endereco.Complemento;
        unidade.Endereco.Bairro = request.Endereco.Bairro;
        unidade.Endereco.Cidade = request.Endereco.Cidade;
        unidade.Endereco.Estado = request.Endereco.Estado;
        unidade.Endereco.Cep = request.Endereco.Cep;


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
