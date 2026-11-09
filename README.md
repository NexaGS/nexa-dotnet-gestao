# Nexa .NET

API REST da solução Nexa/CitizenTech para a disciplina Advanced Business Development with .NET — Global Solution 2026/2.

Projeto orientado a ASP.NET Core 8, Entity Framework Core, Oracle FIAP e Migrations.

## Objetivo

Criar uma API REST para gestão de unidades de saúde e atendimentos:

```text
UnidadeSaude 1 ---- N Atendimento
```

A API .NET será complementar ao Spring Boot. Não é necessário duplicar autenticação, geolocalização ou integração real com SUS.

## Requisitos

- ASP.NET Core 8 Web API com Controllers;
- Entity Framework Core;
- Provider Oracle.EntityFrameworkCore;
- Migrations versionadas;
- Duas entidades relacionadas em 1:N;
- CRUD completo;
- POST retornando 201;
- PUT e DELETE retornando 204;
- Erros de validação retornando 400;
- IDs inexistentes retornando 404.

## Entidades

### UnidadeSaude

- Id
- Nome
- Endereco
- Cep
- Tipo
- Ativa

### Atendimento

- Id
- PacienteCpf
- PacienteNome
- Status
- Prioridade
- DataEntrada
- UnidadeSaudeId

## Pré-requisitos

- .NET SDK 8;
- acesso ao Oracle da FIAP;
- ferramenta dotnet-ef.

```bash
dotnet tool install --global dotnet-ef
```

## Criar o projeto

```bash
dotnet new webapi -n Nexa.DotNet --use-controllers
cd Nexa.DotNet
dotnet add package Microsoft.EntityFrameworkCore --version 8.*
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
dotnet add package Oracle.EntityFrameworkCore
```

## Configuração segura

Nunca versionar senha ou connection string real.

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

As tabelas devem ser criadas exclusivamente pelas Migrations.

Recomenda-se utilizar:

- NET_UNIDADES_SAUDE
- NET_ATENDIMENTOS

## Execução

```bash
dotnet restore
dotnet build
dotnet run
```

## Documentação

- docs/BACKLOG.md
- docs/ARCHITECTURE.md
- docs/API-CONTRACT.md
- docs/DATABASE-MIGRATIONS.md
- docs/PRESENTATION-GUIDE.md

## Integrantes

Preencher com nome completo, RM e turma antes da entrega.
