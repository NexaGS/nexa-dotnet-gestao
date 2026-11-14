using System.ComponentModel.DataAnnotations;

namespace Nexa.Dotnet.DTOs;

public class CriarUnidadeRequest
{
    [Required(ErrorMessage = "O nome da unidade é obrigatório.")]
    [StringLength(maximumLength: 100, ErrorMessage = "O nome da unidade deve ter até 100 caracteres.")]
    public string NomeUnidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O código CNES é obrigatório.")]
    [StringLength(maximumLength: 20, ErrorMessage = "O código CNES deve ter no máximo 20 caracteres.")]
    public string CodigoCnes { get; set; } = string.Empty;

    public bool Ativa { get; set; } = true;

    [Required(ErrorMessage = "Os dados de endereço são obrigatórios.")]
    public EnderecoDto Endereco { get; set; } = new();
}
