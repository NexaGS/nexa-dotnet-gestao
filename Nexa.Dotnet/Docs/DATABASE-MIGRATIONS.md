# Oracle e Migrations

## Tabelas

A Migration deverÃ¡ criar:

- NET_UNIDADES_GESTAO;
- NET_CONFIGURACOES_OPERACIONAIS;
- chave estrangeira entre as tabelas.

## Comandos

```bash
dotnet ef migrations add InitialCreate
dotnet ef migrations list
dotnet ef database update
```

## Regras

- nÃ£o criar tabelas manualmente;
- versionar a pasta Migrations;
- nÃ£o versionar senha;
- usar User Secrets ou variÃ¡vel de ambiente;
- manter tabelas separadas do Spring Boot.

## Checklist

1. Configurar a conexÃ£o Oracle.
2. Executar dotnet ef database update.
3. Conferir as tabelas no Oracle.
4. Conferir a chave estrangeira.
5. Cadastrar uma unidade.
6. Cadastrar uma configuraÃ§Ã£o.
7. Testar erro 400.
8. Testar erro 404.

Nunca versionar senha, .env, dumps ou connection strings reais.
