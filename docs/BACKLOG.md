# Backlog e histórias

## Objetivo

Permitir que gestores cadastrem unidades de saúde e registrem atendimentos do CitizenTech, com persistência no Oracle.

## US01 — Cadastrar unidade

Como gestor, quero cadastrar uma unidade de saúde para disponibilizá-la no CitizenTech.

Critérios de aceite:

- POST /api/unidades;
- campos obrigatórios;
- dados inválidos retornam 400;
- cadastro válido retorna 201;
- resposta contém o ID criado.

## US02 — Consultar unidades

Como usuário, quero listar e consultar unidades cadastradas.

Critérios de aceite:

- GET /api/unidades retorna 200;
- GET /api/unidades/{id} retorna 200;
- ID inexistente retorna 404.

## US03 — Atualizar unidade

Como gestor, quero atualizar os dados de uma unidade.

Critérios de aceite:

- PUT /api/unidades/{id};
- unidade inexistente retorna 404;
- dados inválidos retornam 400;
- sucesso retorna 204.

## US04 — Excluir unidade

Como gestor, quero excluir um cadastro incorreto.

Critérios de aceite:

- DELETE /api/unidades/{id};
- unidade inexistente retorna 404;
- exclusão válida retorna 204;
- recomenda-se impedir exclusão quando houver atendimentos vinculados.

## US05 — Registrar atendimento

Como cidadão ou sistema de atendimento, quero registrar um atendimento vinculado a uma unidade.

Critérios de aceite:

- POST /api/atendimentos;
- a unidade deve existir;
- CPF e nome são obrigatórios;
- unidade inexistente retorna 404;
- cadastro válido retorna 201.

## US06 — Gerenciar atendimentos

Como gestor, quero consultar, alterar e excluir atendimentos.

Critérios de aceite:

- CRUD completo;
- dados inválidos retornam 400;
- ID inexistente retorna 404;
- PUT e DELETE válidos retornam 204.

## Definition of Done

- Projeto compila;
- Migration aplica no Oracle;
- tabelas são criadas;
- relação 1:N funciona;
- respostas 201, 204, 400 e 404 foram demonstradas;
- nenhum segredo está no Git;
- README permite reproduzir a execução.
