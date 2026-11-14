using Microsoft.AspNetCore.Mvc;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;
using Nexa.Dotnet.Services;

namespace Nexa.Dotnet.Controllers;

[ApiController]
[Route("api/unidades-saude")]
public class UnidadesSaudeController : ControllerBase
{
	private readonly UnidadesSaudeService _unidadesSaudeService;

	public UnidadesSaudeController(UnidadesSaudeService unidadesSaudeService)
	{
		_unidadesSaudeService = unidadesSaudeService;
	}

	[HttpGet]
    [ProducesResponseType(typeof(ICollection<UnidadeSaudeGestao>), StatusCodes.Status200OK)]
    public IActionResult ListarUnidades()
	{
		return Ok(_unidadesSaudeService.ListarUnidadesAsync());
	}

	[HttpGet("{id}")]
	[ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult BuscarUnidadeSaude(int id)
	{
		var unidadeSaude = _unidadesSaudeService.BuscarUnidadeSaudeAsync(id);

		if(unidadeSaude == null)
		{
			return NotFound(new {status = 404, mensagem = $"Não foi possível retornar unidade de saúde com ID: {id}" });
		}

        return Ok(unidadeSaude);
	}

	[HttpPost]
    [ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CriarUnidadeSaude([FromBody] CriarUnidadeRequest request)
	{
		var unidade = _unidadesSaudeService.CriarUnidadeAsync(request);

		if(unidade == null)
		{
            return BadRequest($"Não foi possível criar unidade de saúde");
        }

        return CreatedAtAction(nameof(UnidadeSaudeGestao), new { id = unidade.Id }, unidade);
    }


	[HttpPut("{id}")]
    [ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AtualizarUnidadeSaude(int id, [FromBody] AtualizarUnidadeRequest request)
	{
		return NoContent();
	}


	[HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ExcluirUnidadeSaude(int id)
	{
		return NoContent();
	}

}
