# Contrato da API

## Unidades

```http
GET    /api/unidades-gestao
GET    /api/unidades-gestao/{id}
POST   /api/unidades-gestao
PUT    /api/unidades-gestao/{id}
DELETE /api/unidades-gestao/{id}
```

## ConfiguraÃ§Ãµes

```http
GET    /api/configuracoes-operacionais
GET    /api/configuracoes-operacionais/{id}
POST   /api/configuracoes-operacionais
PUT    /api/configuracoes-operacionais/{id}
DELETE /api/configuracoes-operacionais/{id}
```

## POST unidade

```json
{
  "nome": "UBS Vila Mariana",
  "codigoCnes": "1234567",
  "endereco": "Rua Vergueiro, 1000",
  "ativa": true
}
```

Resposta: 201 Created.

## POST configuração

```json
{
  "unidadeGestaoId": 1,
  "diaSemana": "SEGUNDA",
  "horaAbertura": "07:00",
  "horaFechamento": "19:00",
  "capacidadeDiaria": 120,
  "tempoMedioAtendimento": 20,
  "ativa": true
}
```

Resposta: 201 Created.

## Status obrigatórios

- GET válido: 200;
- POST válido: 201;
- PUT válido: 204;
- DELETE válido: 204;
- dado inválido: 400;
- ID inexistente: 404.

## Erro 400

```json
{
  "status": 400,
  "mensagem": "A hora de abertura deve ser anterior ao fechamento."
}
```

## Erro 404

```json
{
  "status": 404,
  "mensagem": "ConfiguraÃ§Ã£o operacional nÃ£o encontrada."
}
```
