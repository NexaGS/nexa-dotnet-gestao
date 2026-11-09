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
