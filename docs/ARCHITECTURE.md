# Arquitetura

## DivisÃ£o entre APIs

### Spring Boot

- pacientes;
- localizaÃ§Ã£o;
- check-in;
- fila;
- encerramento de atendimentos.

### .NET

- cadastro administrativo;
- agenda das unidades;
- capacidade diÃ¡ria;
- tempo mÃ©dio de atendimento.

## Modelo

```text
UnidadeGestao 1 ---- N ConfiguracaoOperacional
```

Uma unidade pode ter uma configuraÃ§Ã£o para cada dia da semana.

## Camadas

```text
Controller -> DTO/Validation -> DbContext -> Oracle
```

## Estrutura

```text
Controllers/
  UnidadesGestaoController.cs
  ConfiguracoesOperacionaisController.cs
Data/
  NexaDbContext.cs
DTOs/
Models/
Migrations/
Exceptions/
Program.cs
```

## Regras

- unidade relacionada deve existir;
- abertura anterior ao fechamento;
- capacidade maior que zero;
- tempo mÃ©dio maior que zero;
- nÃ£o permitir duas configuraÃ§Ãµes ativas para a mesma unidade e dia;
- restringir exclusÃ£o de unidade com configuraÃ§Ãµes vinculadas.

## Erros

Use 400 para validaÃ§Ã£o e 404 quando o recurso nÃ£o existir.
