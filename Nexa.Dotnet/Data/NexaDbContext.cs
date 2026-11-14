using Microsoft.EntityFrameworkCore;
using Nexa.Dotnet.Models;

namespace Nexa.Dotnet.Data;

public class NexaDbContext : DbContext
{
    public NexaDbContext(DbContextOptions<NexaDbContext> options) : base(options)
    {
    }
    public DbSet<UnidadeSaudeGestao> UnidadesSaude => Set<UnidadeSaudeGestao>();
    public DbSet<ConfiguracaoOperacional> ConfiguracoesOperacionais => Set<ConfiguracaoOperacional>();
}