using Microsoft.AspNetCore.Mvc;
using System;

namespace Nexa.Dotnet.Controllers;

[ApiController]
[Route("api/gestao-operacao")]
public class GestaoOperacaoController : Controller
{
	public GestaoOperacaoController()
	{
	}

    [HttpGet]
    public IActionResult ListarOperacoesUnidades()
    {
        return Ok();
    }

    [HttpGet("{unidadeId}")]
    public IActionResult BuscarOperacaoesUnidade(int unidadeId)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult RegistrarOperacaoUnidade()
    {
        return Created();
    }


    [HttpPut("{unidadeId}")]
    public IActionResult AtualizarOperacoesUnidade(int unidadeId)
    {
        return Ok();
    }


    [HttpDelete("{unidadeId}")]
    public IActionResult ExcluirOperacoesUnidade(int unidadeId)
    {
        return NoContent();
    }
}
