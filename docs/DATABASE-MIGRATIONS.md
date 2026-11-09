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
