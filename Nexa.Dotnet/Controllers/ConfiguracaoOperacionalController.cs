using Microsoft.AspNetCore.Mvc;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;
using Nexa.Dotnet.Services;
using System;

namespace Nexa.Dotnet.Controllers;

[ApiController]
[Route("api/configuracoes-operacionais")]
public class ConfiguracaoOperacionalController : ControllerBase
{
    private ConfiguracaoOperacionalService _configuracaoOperacionalService;

    public ConfiguracaoOperacionalController(ConfiguracaoOperacionalService configuracaoOperacionalService)
    {
        _configuracaoOperacionalService = configuracaoOperacionalService;
    }

    //[HttpGet]
    //public IActionResult ListarConfiguracoesUnidades()
    //{
    //    return Ok();
    //}

    [HttpGet("{unidadeId}")]
    [ProducesResponseType(typeof(ConfiguracaoOperacional), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult BuscarConfiguracoesUnidade(int unidadeId)
    {
        var configuracoes = _configuracaoOperacionalService.ListarConfiguracoesUnidadeAsync(unidadeId);
        if(configuracoes == null)
        {
            return NotFound(new { status = 404, mensagem = $"Não foi possível retornar configurações da unidade de saúde de ID: {unidadeId}" });
        }

        return Ok(configuracoes);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ConfiguracaoOperacional), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegistrarConfiguracao([FromBody] CriarConfiguracaoRequest request)
    {
        var configuracao = _configuracaoOperacionalService.CriarConfiguracaoAsync(request);
        if(configuracao == null)
        {
            return BadRequest($"Não foi possível criar nova configuração");
        }
        return CreatedAtAction(nameof(BuscarConfiguracoesUnidade), new {id = configuracao.Id}, configuracao);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ConfiguracaoOperacional), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarConfiguracoes(int id, [FromBody] AtualizarConfiguracaoRequest request)
    {
        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ExcluirConfiguracao(int id)
    {
        var configuracao = await _configuracaoOperacionalService.ExcluirConfiguracaoAsync(id);

        if(!configuracao)
        {
            return NotFound(new { status = 404, mensagem = $"Configuração operacional com {id} não encontrada para exclusão." });
        }

        return NoContent();
    }
}
