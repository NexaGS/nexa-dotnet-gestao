using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;

namespace Nexa.Dotnet.Mapper;

public static class UnidadeSaudeMapper
{
    public static UnidadeDetalhesResponse MapearParaResponse(UnidadeSaudeGestao unidade) => new()
    {
        Id = unidade.Id,   
        NomeUnidade = unidade.NomeUnidade,   
        CodigoCnes = unidade.CodigoCnes,
        Ativa = unidade.Ativa ? "ATIVA" : "INATIVA",
        Endereco = new EnderecoDto
        {
            Logradouro = unidade.Endereco.Logradouro,
            Numero = unidade.Endereco.Numero,
            Complemento = unidade.Endereco.Complemento,
            Bairro = unidade.Endereco.Bairro,
            Cidade = unidade.Endereco.Cidade,
            Estado = unidade.Endereco.Estado,
            Cep = unidade.Endereco.Cep
        },
        Configuracoes = unidade.Configuracoes
            .Select(ConfiguracaoOperacionalMapper.MapearParaResponse)
            .ToList()

    };
}
