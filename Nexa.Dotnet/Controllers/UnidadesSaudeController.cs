using Microsoft.AspNetCore.Mvc;
using Nexa.Dotnet.Models;
using System;

namespace Nexa.Dotnet.Controllers;

[ApiController]
[Route("api/unidades-saude")]
public class UnidadesSaudeController : ControllerBase
{

	[HttpGet]
	public IActionResult ListarUnidades()
	{
		return Ok();
	}

	[HttpGet("{id}")]
	public IActionResult BuscarUnidadeSaude(int id)
	{
		return Ok();
	}

	[HttpPost]
	public IActionResult CriarUnidadeSaude()
	{
		return Created();
	}


	[HttpPut("{id}")]
	public IActionResult AtualizarUnidadeSaude(int id)
	{
		return Ok();
	}


	[HttpDelete("{id}")]
	public IActionResult ExcluirUnidadeSaude(int id)
	{
		return NoContent();
	}


	
}
