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
