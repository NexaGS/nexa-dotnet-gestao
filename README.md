# Nexa .NET

API REST complementar do CitizenTech para a disciplina Advanced Business Development with .NET.

O Spring Boot permanece responsável por pacientes, localização, check-in e fila. O .NET será o módulo administrativo de agenda e capacidade das unidades.

## Modelo

```text
UnidadeGestao 1 ---- N ConfiguracaoOperacional
```

## Entidades

### UnidadeGestao

- Id
- Nome
- CodigoCnes
- Endereco
- Ativa

### ConfiguracaoOperacional

- Id
- UnidadeGestaoId
- DiaSemana
- HoraAbertura
- HoraFechamento
- CapacidadeDiaria
- TempoMedioAtendimento
- Ativa

## Tecnologias

- ASP.NET Core 8 Web API;
- Entity Framework Core;
- Oracle.EntityFrameworkCore;
- Oracle FIAP;
- EF Core Migrations.

## Escopo

- CRUD de unidades administrativas;
- CRUD de configurações operacionais;
- agenda semanal;
- capacidade diária;
- tempo médio de atendimento;
- validações;
- respostas HTTP 201, 204, 400 e 404.

Não fazem parte desta entrega autenticação, integração real com SUS, geolocalização ou fila em tempo real.

## Pacotes

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.*
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
dotnet add package Oracle.EntityFrameworkCore
dotnet tool install --global dotnet-ef
```

## Oracle

Nunca versionar senha.

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Oracle" "User Id=RMXXXXXX;Password=SENHA;Data Source=oracle.fiap.com.br:1521/ORCL"
```

## Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations list
```

As tabelas recomendadas sÃ£o:

- NET_UNIDADES_GESTAO
- NET_CONFIGURACOES_OPERACIONAIS

## Execução

```bash
dotnet restore
dotnet build
dotnet run
```

## Documentação

- Nexa.Dotnet/Docs/PLANO-DESENVOLVIMENTO-GUIA.md (Plano Diretor, Status & Micro-sprints)
- Nexa.Dotnet/Docs/BACKLOG.md
- Nexa.Dotnet/Docs/ARCHITECTURE.md
- Nexa.Dotnet/Docs/API-CONTRACT.md
- Nexa.Dotnet/Docs/DATABASE-MIGRATIONS.md
- Nexa.Dotnet/Docs/PRESENTATION-GUIDE.md

## Integrantes

Preencher com nome, RM e turma.
