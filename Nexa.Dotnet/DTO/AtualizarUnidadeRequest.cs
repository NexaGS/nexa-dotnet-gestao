using System.ComponentModel.DataAnnotations;

namespace Nexa.Dotnet.DTOs;

public class AtualizarUnidadeRequest
{
    [Required(ErrorMessage = "O nome da unidade é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome da unidade deve ter entre 3 e 150 caracteres.")]
    public string NomeUnidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O código CNES é obrigatório.")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "O código CNES deve ter entre 4 e 20 caracteres.")]
    public string CodigoCnes { get; set; } = string.Empty;

    public bool Ativa { get; set; }

    [Required(ErrorMessage = "Os dados de endereço são obrigatórios.")]
    public EnderecoDto Endereco { get; set; } = new();
}
