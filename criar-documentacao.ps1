$ErrorActionPreference = "Stop"

New-Item -ItemType Directory -Force docs | Out-Null

@'
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
'@ | Set-Content README.md -Encoding utf8

@'
# Backlog e histórias

## Objetivo

Permitir que gestores cadastrem unidades de saúde e registrem atendimentos do CitizenTech, com persistência no Oracle.

## US01 — Cadastrar unidade

Como gestor, quero cadastrar uma unidade de saúde para disponibilizá-la no CitizenTech.

Critérios de aceite:

- POST /api/unidades;
- campos obrigatórios;
- dados inválidos retornam 400;
- cadastro válido retorna 201;
- resposta contém o ID criado.

## US02 — Consultar unidades

Como usuário, quero listar e consultar unidades cadastradas.

Critérios de aceite:

- GET /api/unidades retorna 200;
- GET /api/unidades/{id} retorna 200;
- ID inexistente retorna 404.

## US03 — Atualizar unidade

Como gestor, quero atualizar os dados de uma unidade.

Critérios de aceite:

- PUT /api/unidades/{id};
- unidade inexistente retorna 404;
- dados inválidos retornam 400;
- sucesso retorna 204.

## US04 — Excluir unidade

Como gestor, quero excluir um cadastro incorreto.

Critérios de aceite:

- DELETE /api/unidades/{id};
- unidade inexistente retorna 404;
- exclusão válida retorna 204;
- recomenda-se impedir exclusão quando houver atendimentos vinculados.

## US05 — Registrar atendimento

Como cidadão ou sistema de atendimento, quero registrar um atendimento vinculado a uma unidade.

Critérios de aceite:

- POST /api/atendimentos;
- a unidade deve existir;
- CPF e nome são obrigatórios;
- unidade inexistente retorna 404;
- cadastro válido retorna 201.

## US06 — Gerenciar atendimentos

Como gestor, quero consultar, alterar e excluir atendimentos.

Critérios de aceite:

- CRUD completo;
- dados inválidos retornam 400;
- ID inexistente retorna 404;
- PUT e DELETE válidos retornam 204.

## Definition of Done

- Projeto compila;
- Migration aplica no Oracle;
- tabelas são criadas;
- relação 1:N funciona;
- respostas 201, 204, 400 e 404 foram demonstradas;
- nenhum segredo está no Git;
- README permite reproduzir a execução.
'@ | Set-Content docs/BACKLOG.md -Encoding utf8

@'
# Arquitetura e implementação

## Camadas

```text
HTTP Controller -> DTO/Validation -> DbContext -> Oracle
```

## Estrutura sugerida

```text
Controllers/
Data/
DTOs/
Models/
Migrations/
Exceptions/
Program.cs
appsettings.json
```

## Relacionamento

Uma UnidadeSaude possui muitos Atendimentos.

O Atendimento deve possuir:

- propriedade UnidadeSaudeId;
- propriedade de navegação UnidadeSaude;
- chave estrangeira obrigatória.

Configure no DbContext:

- tabela NET_UNIDADES_SAUDE;
- tabela NET_ATENDIMENTOS;
- relacionamento HasOne/WithMany;
- chave estrangeira;
- delete restrito;
- tamanhos e campos obrigatórios.

## Validações

Regras mínimas:

- Nome obrigatório, entre 3 e 150 caracteres;
- CEP no formato 00000-000;
- CPF com 11 dígitos;
- Status: ABERTO, EM_ATENDIMENTO ou ENCERRADO;
- Prioridade: NORMAL ou PRIORITARIO;
- UnidadeSaudeId obrigatório;
- unidade informada deve existir.

Use DataAnnotations ou FluentValidation.

O atributo [ApiController] pode retornar 400 automaticamente para ModelState inválido.

## Controllers

Cada Controller deve implementar:

- GET lista;
- GET por ID;
- POST;
- PUT;
- DELETE.

O POST deve usar CreatedAtAction.

PUT e DELETE devem retornar NoContent.

## Tratamento de erros

Use NotFound quando o recurso não existir.

Formato sugerido:

```json
{
  "status": 404,
  "mensagem": "Unidade de saúde não encontrada.",
  "timestamp": "2026-11-09T18:30:00Z"
}
```
'@ | Set-Content docs/ARCHITECTURE.md -Encoding utf8

@'
# Contrato da API

## Rotas

```text
GET    /api/unidades
GET    /api/unidades/{id}
POST   /api/unidades
PUT    /api/unidades/{id}
DELETE /api/unidades/{id}

GET    /api/atendimentos
GET    /api/atendimentos/{id}
POST   /api/atendimentos
PUT    /api/atendimentos/{id}
DELETE /api/atendimentos/{id}
```

## POST unidade

```json
{
  "nome": "UBS Vila Mariana",
  "endereco": "Rua Vergueiro, 1000",
  "cep": "04101-000",
  "tipo": "UBS",
  "ativa": true
}
```

Resposta esperada: 201 Created.

## POST atendimento

```json
{
  "pacienteCpf": "12345678901",
  "pacienteNome": "Maria da Silva",
  "status": "ABERTO",
  "prioridade": "NORMAL",
  "dataEntrada": "2026-11-09T18:30:00",
  "unidadeSaudeId": 1
}
```

Resposta esperada: 201 Created.

## Status HTTP

- GET válido: 200;
- POST válido: 201;
- PUT válido: 204;
- DELETE válido: 204;
- dados inválidos: 400;
- ID inexistente: 404.

## Erro 400

```json
{
  "status": 400,
  "mensagem": "Existem dados inválidos.",
  "erros": [
    {
      "campo": "Nome",
      "mensagem": "O nome é obrigatório."
    }
  ]
}
```

## Erro 404

```json
{
  "status": 404,
  "mensagem": "Unidade de saúde não encontrada."
}
```
'@ | Set-Content docs/API-CONTRACT.md -Encoding utf8

@'
# Oracle e Migrations

## Regras

- O schema deve ser criado por EF Core Migrations;
- não criar tabelas manualmente;
- versionar a pasta Migrations;
- não versionar senha;
- usar tabelas próprias da API .NET.

## Comandos

```bash
dotnet ef migrations add InitialCreate
dotnet ef migrations list
dotnet ef database update
```

Para uma alteração futura:

```bash
dotnet ef migrations add NomeDaAlteracao
dotnet ef database update
```

## Checklist

1. Configurar a connection string com Secret Manager;
2. executar dotnet ef database update;
3. conferir as tabelas no Oracle;
4. cadastrar uma unidade;
5. cadastrar um atendimento;
6. conferir a chave estrangeira;
7. demonstrar os status HTTP.

## Segurança

O repositório não deve conter:

- senha;
- usuário Oracle;
- arquivo .env;
- connection string real;
- dumps do banco.

Use User Secrets ou variáveis de ambiente.
'@ | Set-Content docs/DATABASE-MIGRATIONS.md -Encoding utf8

@'
# Roteiro da apresentação

## Demonstração

1. Apresentar o CitizenTech.
2. Explicar que o Spring Boot atende a operação e o .NET atende o CRUD complementar.
3. Mostrar o relacionamento UnidadeSaude 1:N Atendimento.
4. Mostrar as entidades e o DbContext.
5. Mostrar a pasta Migrations.
6. Executar a Migration no Oracle.
7. Mostrar as tabelas NET_UNIDADES_SAUDE e NET_ATENDIMENTOS.
8. Fazer POST de unidade e demonstrar 201.
9. Fazer POST de atendimento e demonstrar 201.
10. Fazer PUT e DELETE e demonstrar 204.
11. Fazer POST inválido e demonstrar 400.
12. Consultar ID inexistente e demonstrar 404.

## Perguntas prováveis

### Por que duas entidades?

Para demonstrar o relacionamento 1:N exigido pela disciplina.

### Por que usar Migrations?

Para versionar e reproduzir a criação do banco sem criar tabelas manualmente.

### Qual é o fluxo da requisição?

O Controller recebe a requisição, valida o DTO, usa o DbContext, persiste no Oracle e retorna o status HTTP adequado.

### Por que o CPF não consulta o SUS real?

A integração SUS é uma evolução do produto. Esta entrega exige principalmente CRUD, persistência, relacionamento e validações.
'@ | Set-Content docs/PRESENTATION-GUIDE.md -Encoding utf8

Write-Host "Documentacao criada com sucesso."