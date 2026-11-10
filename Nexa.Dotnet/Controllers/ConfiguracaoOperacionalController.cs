using Microsoft.AspNetCore.Mvc;
using System;

namespace Nexa.Dotnet.Controllers;

[ApiController]
[Route("api/configuracoes-operacionais")]
public class ConfiguracaoOperacionalController : Controller
{
	public ConfiguracaoOperacionalController()
	{
	}

    [HttpGet]
    public IActionResult ListarConfiguracoesUnidades()
    {
        return Ok();
    }

    [HttpGet("{unidadeId}")]
    public IActionResult BuscarConfiguracoesUnidade(int unidadeId)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult RegistrarConfiguracao()
    {
        return Created();
    }


    [HttpPut("{id}")]
    public IActionResult AtualizarConfiguracoes(int id)
    {
        return Ok();
    }


    [HttpDelete("{id}")]
    public IActionResult ExcluirConfiguraco(int id)
    {
        return NoContent();
    }
}
