using Microsoft.AspNetCore.Mvc;
using Nexa.Dotnet.DTOs;
using Nexa.Dotnet.Models;
using Nexa.Dotnet.Services;
using System.ComponentModel.DataAnnotations;

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
    public async Task<IActionResult> CriarUnidadeSaude([FromBody] CriarUnidadeRequest request)
	{
		var unidade = _unidadesSaudeService.CriarUnidadeAsync(request);

		if(unidade == null)
		{
            return BadRequest(new { status = 400, mensagem = "Não foi possível criar unidade de saúde" });
        }

        return CreatedAtAction(nameof(BuscarUnidadeSaude), new { id = unidade.Id }, unidade);
    }


	[HttpPut("{id}/nome")]
    [ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarNomeUnidadeSaude([Required] int id, string nome)
	{
        var unidadeAtualizada = await _unidadesSaudeService.AtualizarNomeUnidadeAsync(id, nome);

		if(unidadeAtualizada == null)
		{
            return NotFound(new { status = 404, mensagem = $"Unidade de saúde com ID {id} não encontrada para atualização." });
        }

        return NoContent();
	}

	[HttpPut("{id}/ativar-unidade")]
    [ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtivarUnidadeSaude(int id)
	{
        var unidadeAtualizada = await _unidadesSaudeService.TornarStatusAtivoUnidadeAsync(id);
		
		if(unidadeAtualizada == null)
		{
            return NotFound(new { status = 404, mensagem = $"Unidade de saúde com ID {id} não encontrada para atualização." });
        }

        return NoContent();
	}

	[HttpPut("{id}/desativar-unidade")]
    [ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> InativarUnidadeSaude(int id)
	{
        var unidadeAtualizada = await _unidadesSaudeService.TornarStatusInativoUnidadeAsync(id);
		
		if(unidadeAtualizada == null)
		{
            return NotFound(new { status = 404, mensagem = $"Unidade de saúde com ID {id} não encontrada para atualização." });
        }

        return NoContent();
	}

	[HttpPut("{id}/endereco")]
    [ProducesResponseType(typeof(UnidadeSaudeGestao), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarEnderecoUnidadeSaude(int id, [FromBody] EnderecoDto request)
	{
        var unidadeAtualizada = await _unidadesSaudeService.AtualizarEnderecoUnidadeAsync(id, request);

		if(unidadeAtualizada == null)
		{
            return NotFound(new { status = 404, mensagem = $"Unidade de saúde com ID {id} não encontrada para atualização." });
        }

        return NoContent();
	}


	[HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ExcluirUnidadeSaude(int id)
	{
		var unidade = await _unidadesSaudeService.ExcluirUnidadeAsync(id);

		if (!unidade)
		{
            return NotFound(new { status = 404, mensagem = $"Unidade de saúde com ID {id} não encontrada." });
        }

		return NoContent();
	}

}
