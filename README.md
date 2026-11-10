# Nexa .NET

API REST complementar do CitizenTech para a disciplina Advanced Business Development with .NET.

O Spring Boot permanece responsÃ¡vel por pacientes, localizaÃ§Ã£o, check-in e fila. O .NET serÃ¡ o mÃ³dulo administrativo de agenda e capacidade das unidades.

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
- CRUD de configuraÃ§Ãµes operacionais;
- agenda semanal;
- capacidade diÃ¡ria;
- tempo mÃ©dio de atendimento;
- validaÃ§Ãµes;
- respostas HTTP 201, 204, 400 e 404.

NÃ£o fazem parte desta entrega autenticaÃ§Ã£o, integraÃ§Ã£o real com SUS, geolocalizaÃ§Ã£o ou fila em tempo real.

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

## ExecuÃ§Ã£o

```bash
dotnet restore
dotnet build
dotnet run
```

## DocumentaÃ§Ã£o

- docs/BACKLOG.md
- docs/ARCHITECTURE.md
- docs/API-CONTRACT.md
- docs/DATABASE-MIGRATIONS.md
- docs/PRESENTATION-GUIDE.md

## Integrantes

Preencher com nome, RM e turma.
