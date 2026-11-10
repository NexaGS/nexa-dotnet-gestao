# Roteiro da apresentaÃ§Ã£o

1. Apresentar o CitizenTech.
2. Explicar que o Spring Boot opera pacientes, localizaÃ§Ã£o e fila.
3. Explicar que o .NET administra agenda e capacidade.
4. Mostrar o relacionamento UnidadeGestao 1:N ConfiguracaoOperacional.
5. Mostrar entidades, DTOs e DbContext.
6. Mostrar a pasta Migrations.
7. Aplicar a Migration no Oracle.
8. Mostrar as tabelas criadas.
9. Criar uma unidade e demonstrar 201.
10. Criar uma configuraÃ§Ã£o e demonstrar 201.
11. Atualizar a capacidade e demonstrar 204.
12. Enviar horÃ¡rio invÃ¡lido e demonstrar 400.
13. Consultar ID inexistente e demonstrar 404.

## Perguntas provÃ¡veis

### A API calcula a fila?

NÃ£o. Ela mantÃ©m as configuraÃ§Ãµes administrativas. A fila continua no Spring Boot.

### Por que separar as APIs?

Para separar operaÃ§Ã£o do cidadÃ£o e gestÃ£o administrativa.

### Por que a relaÃ§Ã£o Ã© 1:N?

Uma unidade pode ter configuraÃ§Ãµes diferentes para cada dia da semana.

### Por que usar Migrations?

Para versionar e reproduzir o banco Oracle sem criar tabelas manualmente.
