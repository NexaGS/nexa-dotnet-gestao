using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexa.Dotnet.Models;

[Owned]
public class Endereco
{
    [Required]
    [MaxLength(150)]
    [Column("logradouro")]
    public string Logradouro { get; set; } = string.Empty;

    [MaxLength(6)]
    [Column("numero")]
    public string? Numero { get; set; } = string.Empty;

    [MaxLength(35)]
    [Column("complemento")]
    public string? Complemento { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [Column("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("cidade")]
    public string Cidade { get; set; } = string.Empty;

    [Required]
    [MaxLength(2)]
    [Column("estado")]
    public string Estado { get; set; } = string.Empty;

    [Required]
    [MaxLength(8)]
    [Column("cep")]
    public string Cep { get; set; } = string.Empty;
}
