using Microsoft.AspNetCore.Mvc;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;
using Nexa.Dotnet.Services;
using System;

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
			return NotFound("Unidade de saúde não encontrada");
		}

        return Ok(unidadeSaude);
	}

	[HttpPost]
    [ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CriarUnidadeSaude([FromBody] CriarUnidadeRequest request)
	{
		return Created();
	}


	[HttpPut("{id}")]
	public IActionResult AtualizarUnidadeSaude(int id, [FromBody] AtualizarUnidadeRequest request)
	{
		return Ok();
	}


	[HttpDelete("{id}")]
	public IActionResult ExcluirUnidadeSaude(int id)
	{
		return NoContent();
	}


	
}
