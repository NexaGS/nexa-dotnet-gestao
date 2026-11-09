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
