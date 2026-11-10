using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexa.Dotnet.Models;

namespace Nexa.Dotnet.Data;

public class NexaDbContext : DbContext
{
    public NexaDbContext(DbContextOptions<NexaDbContext> options) : base(options)
    {
    }

    public DbSet<UnidadeSaudeGestao> UnidadesSaude => Set<UnidadeSaudeGestao>();
    public DbSet<ConfiguracaoOperacional> ConfiguracoesOperacionais => Set<ConfiguracaoOperacional>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Conversor seguro para TimeOnly no Oracle (persiste como string "HH:mm")
        var timeOnlyConverter = new ValueConverter<TimeOnly, string>(
            time => time.ToString("HH:mm"),
            str => TimeOnly.Parse(str)
        );

        // Mapeamento da Entidade UnidadeSaudeGestao
        modelBuilder.Entity<UnidadeSaudeGestao>(entity =>
        {
            entity.ToTable("NET_UNIDADES_GESTAO");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            entity.Property(u => u.NomeUnidade)
                .HasColumnName("NOME_UNIDADE")
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(u => u.CodigoCnes)
                .HasColumnName("CODIGO_CNES")
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(u => u.Ativa)
                .HasColumnName("ATIVA")
                .IsRequired();

            // Mapeamento do Value Object Endereco (Owned Entity)
            entity.OwnsOne(u => u.Endereco, end =>
            {
                end.Property(e => e.Logradouro)
                    .HasColumnName("LOGRADOURO")
                    .HasMaxLength(150)
                    .IsRequired();

                end.Property(e => e.Numero)
                    .HasColumnName("NUMERO")
                    .HasMaxLength(20)
                    .IsRequired();

                end.Property(e => e.Complemento)
                    .HasColumnName("COMPLEMENTO")
                    .HasMaxLength(50);

                end.Property(e => e.Bairro)
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(100)
                    .IsRequired();

                end.Property(e => e.Cidade)
                    .HasColumnName("CIDADE")
                    .HasMaxLength(100)
                    .IsRequired();

                end.Property(e => e.Estado)
                    .HasColumnName("ESTADO_UF")
                    .HasMaxLength(2)
                    .IsRequired();

                end.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(10)
                    .IsRequired();
            });

            // Relacionamento 1:N
            entity.HasMany(u => u.Configuracoes)
                .WithOne(c => c.UnidadeSaude)
                .HasForeignKey(c => c.UnidadeSaudeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Mapeamento da Entidade ConfiguracaoOperacional
        modelBuilder.Entity<ConfiguracaoOperacional>(entity =>
        {
            entity.ToTable("NET_CONFIGURACOES_OPERACIONAIS");
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            entity.Property(c => c.UnidadeSaudeId)
                .HasColumnName("UNIDADE_SAUDE_ID")
                .IsRequired();

            entity.Property(c => c.DiaSemana)
                .HasColumnName("DIA_SEMANA")
                .HasConversion<int>()
                .IsRequired();

            entity.Property(c => c.HoraAbertura)
                .HasColumnName("HORA_ABERTURA")
                .HasMaxLength(5)
                .HasConversion(timeOnlyConverter)
                .IsRequired();

            entity.Property(c => c.HoraFechamento)
                .HasColumnName("HORA_FECHAMENTO")
                .HasMaxLength(5)
                .HasConversion(timeOnlyConverter)
                .IsRequired();

            entity.Property(c => c.CapacidadeDiaria)
                .HasColumnName("CAPACIDADE_DIARIA")
                .IsRequired();

            entity.Property(c => c.TempoMedioAtendimentoMinutos)
                .HasColumnName("TEMPO_MEDIO_MINUTOS")
                .IsRequired();

            entity.Property(c => c.ConfiguracaoAtiva)
                .HasColumnName("CONFIGURACAO_ATIVA")
                .IsRequired();
        });
    }
}
