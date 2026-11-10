# Backlog

## Objetivo

Permitir que gestores configurem os horÃ¡rios e a capacidade de atendimento das unidades do CitizenTech.

## US01 â€” Cadastrar unidade

Como gestor, quero cadastrar uma unidade administrativa.

CritÃ©rios:

- POST /api/unidades-gestao;
- nome, cÃ³digo CNES e endereÃ§o obrigatÃ³rios;
- dados invÃ¡lidos retornam 400;
- cadastro vÃ¡lido retorna 201.

## US02 â€” Consultar unidades

Como gestor, quero consultar unidades cadastradas.

CritÃ©rios:

- GET /api/unidades-gestao retorna 200;
- GET /api/unidades-gestao/{id} retorna 200;
- ID inexistente retorna 404.

## US03 â€” Atualizar unidade

Como gestor, quero atualizar os dados da unidade.

CritÃ©rios:

- PUT /api/unidades-gestao/{id};
- dados invÃ¡lidos retornam 400;
- unidade inexistente retorna 404;
- sucesso retorna 204.

## US04 â€” Excluir unidade

Como gestor, quero excluir uma unidade incorreta.

CritÃ©rios:

- DELETE /api/unidades-gestao/{id};
- unidade inexistente retorna 404;
- sucesso retorna 204;
- unidade com configuraÃ§Ãµes deve ter a exclusÃ£o restringida.

## US05 â€” Cadastrar configuraÃ§Ã£o operacional

Como gestor, quero configurar o funcionamento de uma unidade.

CritÃ©rios:

- POST /api/configuracoes-operacionais;
- unidade relacionada deve existir;
- horÃ¡rio de abertura deve ser anterior ao fechamento;
- capacidade deve ser maior que zero;
- tempo mÃ©dio deve ser maior que zero;
- sucesso retorna 201.

## US06 â€” Consultar configuraÃ§Ãµes

Como gestor, quero visualizar a agenda e a capacidade da unidade.

CritÃ©rios:

- GET /api/configuracoes-operacionais;
- filtro opcional por unidadeGestaoId;
- consulta por ID retorna 200;
- ID inexistente retorna 404.

## US07 â€” Atualizar configuraÃ§Ã£o

Como gestor, quero alterar horÃ¡rio, capacidade ou tempo mÃ©dio.

CritÃ©rios:

- PUT /api/configuracoes-operacionais/{id};
- nÃ£o permitir duas configuraÃ§Ãµes ativas para a mesma unidade e dia;
- dados invÃ¡lidos retornam 400;
- sucesso retorna 204.

## US08 â€” Excluir configuraÃ§Ã£o

Como gestor, quero remover uma configuraÃ§Ã£o incorreta.

CritÃ©rios:

- DELETE /api/configuracoes-operacionais/{id};
- ID inexistente retorna 404;
- sucesso retorna 204.

## Definition of Done

- Projeto compila;
- Migration aplica no Oracle;
- duas entidades possuem relacionamento 1:N;
- CRUD completo funciona;
- respostas 201, 204, 400 e 404 foram demonstradas;
- nenhum segredo foi versionado;
- README permite executar o projeto.
