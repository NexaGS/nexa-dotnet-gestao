# 📑 Contrato da API REST — Nexa .NET

## 🏥 1. Endpoints de Unidades de Saúde (`/api/unidades-saude`)

| Método | Rota | Descrição | Status Sucesso | Status Erro |
| :--- | :--- | :--- | :---: | :---: |
| `GET` | `/api/unidades-saude` | Listagem de todas as unidades | `200 OK` | - |
| `GET` | `/api/unidades-saude/{id}` | Busca de unidade por ID | `200 OK` | `404 Not Found` |
| `POST` | `/api/unidades-saude` | Cadastro de nova unidade | `201 Created` | `400 Bad Request` |
| `PUT` | `/api/unidades-saude/{id}/nome` | Atualização do nome da unidade | `204 NoContent` | `404 Not Found` |
| `PUT` | `/api/unidades-saude/{id}/ativar-unidade` | Ativa a unidade de saúde | `204 NoContent` | `400 / 404` |
| `PUT` | `/api/unidades-saude/{id}/desativar-unidade` | Desativa a unidade de saúde | `204 NoContent` | `400 / 404` |
| `PUT` | `/api/unidades-saude/{id}/endereco` | Atualização do endereço da unidade | `204 NoContent` | `404 Not Found` |
| `DELETE` | `/api/unidades-saude/{id}` | Exclusão de unidade | `204 NoContent` | `404 Not Found` |

### Exemplo de Payload — POST Unidade
```json
{
  "nomeUnidade": "UBS Vila Mariana - Dr. Cláudio",
  "codigoCnes": "2078015",
  "ativa": true,
  "endereco": {
    "logradouro": "Rua Domingos de Morais",
    "numero": "800",
    "complemento": "Bloco A",
    "bairro": "Vila Mariana",
    "cidade": "São Paulo",
    "estado": "SP",
    "cep": "04010000"
  }
}
```

---

## ⚙️ 2. Endpoints de Configurações Operacionais (`/api/configuracoes-operacionais`)

| Método | Rota | Descrição | Status Sucesso | Status Erro |
| :--- | :--- | :--- | :---: | :---: |
| `GET` | `/api/configuracoes-operacionais/{unidadeId}` | Lista configurações de uma unidade | `200 OK` | `404 Not Found` |
| `POST` | `/api/configuracoes-operacionais` | Cadastra regra de funcionamento semanal | `201 Created` | `400 Bad Request` |
| `PUT` | `/api/configuracoes-operacionais/{id}` | Atualiza horários e capacidade | `204 NoContent` | `400 / 404` |
| `DELETE` | `/api/configuracoes-operacionais/{id}` | Exclui regra de funcionamento | `204 NoContent` | `404 Not Found` |

### Exemplo de Payload — POST Configuração
```json
{
  "unidadeSaudeId": 1,
  "diaSemana": 1,
  "horaAbertura": "07:00",
  "horaFechamento": "19:00",
  "capacidadeDiaria": 120,
  "tempoMedioAtendimentoMinutos": 15,
  "configuracaoAtiva": true
}
```
*(Nota: `diaSemana: 1` corresponde a `Segunda` no enum `DiaDaSemana`).*

---

## 🛡️ 3. Padrão de Retorno de Erros (Critérios FIAP)

### Erro 400 — Bad Request (Validação de Regra de Negócio)
```json
{
  "status": 400,
  "erros": [
    "Hora da abertura deve ser anterior a hora de fechamento.",
    "Capacidade diária da unidade deve ser maior que 0."
  ]
}
```

### Erro 404 — Not Found (Recurso Inexistente)
```json
{
  "status": 404,
  "mensagem": "Não foi possível retornar unidade de saúde com ID: 99"
}
```
