using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexa.Dotnet.Models;

[Table("tb_unidades_gestao")]
public class UnidadeSaudeGestao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("nome_unidade")]
    public string NomeUnidade { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [Column("codigo_cnes_unidade")]
    public string CodigoCnes { get; set; } = string.Empty;

    [Column("ativa")]
    public bool Ativa { get; set; } = true;
    public Endereco Endereco { get; set; } = new();
    public ICollection<ConfiguracaoOperacional> Configuracoes { get; set; } = new List<ConfiguracaoOperacional>();

    public UnidadeSaudeGestao()
    {
    }
}
