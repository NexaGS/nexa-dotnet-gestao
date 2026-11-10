# Arquitetura

## Divisão entre APIs

### Spring Boot

- pacientes;
- localização;
- check-in;
- fila;
- encerramento de atendimentos.

### .NET

- cadastro administrativo;
- agenda das unidades;
- capacidade diária;
- tempo médio de atendimento.

## Modelo

```text
UnidadeGestao 1 ---- N ConfiguracaoOperacional
```

Uma unidade pode ter uma configuração para cada dia da semana.

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
- tempo médio maior que zero;
- não permitir duas configurações ativas para a mesma unidade e dia;
- restringir exclusão de unidade com configurações vinculadas.

## Erros

Use 400 para validação e 404 quando o recurso não existir.
