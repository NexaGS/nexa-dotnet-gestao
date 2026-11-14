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
            return NotFound("Configurações não retornadas.");
        }

        return Ok(configuracoes);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ConfiguracaoOperacional), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult RegistrarConfiguracao([FromBody] CriarConfiguracaoRequest request)
    {
        var configuracao = _configuracaoOperacionalService.CriarConfiguracaoOperacional(request);
        if(configuracao == null)
        {
            return BadRequest("Dados de configuração inválidos!");
        }
        return Created($"api/configuracoes/{configuracao.Id}", configuracao);
    }


    [HttpPut("{id}")]
    public IActionResult AtualizarConfiguracoes(int id, [FromBody] AtualizarConfiguracaoRequest request)
    {
        return Ok();
    }


    [HttpDelete("{id}")]
    public IActionResult ExcluirConfiguracao(int id)
    {
        return NoContent();
    }
}
