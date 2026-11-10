using System.ComponentModel.DataAnnotations;

namespace Nexa.Dotnet.DTOs;

public class EnderecoDto
{
    [Required(ErrorMessage = "O logradouro é obrigatório.")]
    [StringLength(150, ErrorMessage = "O logradouro deve ter no máximo 150 caracteres.")]
    public string Logradouro { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número é obrigatório.")]
    [StringLength(20, ErrorMessage = "O número deve ter no máximo 20 caracteres.")]
    public string Numero { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "O complemento deve ter no máximo 50 caracteres.")]
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "O bairro é obrigatório.")]
    [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres.")]
    public string Bairro { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cidade é obrigatória.")]
    [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado (UF) é obrigatório.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve conter a sigla com 2 caracteres (ex: SP).")]
    public string Estado { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CEP é obrigatório.")]
    [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "CEP deve estar no formato 00000000 ou 00000-000.")]
    public string Cep { get; set; } = string.Empty;
}
