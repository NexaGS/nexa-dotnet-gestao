# Backlog

## Objetivo

Permitir que gestores configurem os horários e a capacidade de atendimento das unidades do CitizenTech.

## US01 - Cadastrar unidade

Como gestor, quero cadastrar uma unidade administrativa.

Critérios:

- POST /api/unidades-gestao;
- nome, código CNES e endereço obrigatórios;
- dados inválidos retornam 400;
- cadastro válido retorna 201.

## US02 - Consultar unidades

Como gestor, quero consultar unidades cadastradas.

Critérios:

- GET /api/unidades-gestao retorna 200;
- GET /api/unidades-gestao/{id} retorna 200;
- ID inexistente retorna 404.

## US03 - Atualizar unidade

Como gestor, quero atualizar os dados da unidade.

Critérios:

- PUT /api/unidades-gestao/{id};
- dados inválidos retornam 400;
- unidade inexistente retorna 404;
- sucesso retorna 204.

## US04 - Excluir unidade

Como gestor, quero excluir uma unidade incorreta.

Critérios:

- DELETE /api/unidades-gestao/{id};
- unidade inexistente retorna 404;
- sucesso retorna 204;
- unidade com configurações deve ter a exclusÃ£o restringida.

## US05 - Cadastrar configuração operacional

Como gestor, quero configurar o funcionamento de uma unidade.

Critérios:

- POST /api/configuracoes-operacionais;
- unidade relacionada deve existir;
- horário de abertura deve ser anterior ao fechamento;
- capacidade deve ser maior que zero;
- tempo médio deve ser maior que zero;
- sucesso retorna 201.

## US06 - Consultar configurações

Como gestor, quero visualizar a agenda e a capacidade da unidade.

Critérios:

- GET /api/configuracoes-operacionais;
- filtro opcional por unidadeGestaoId;
- consulta por ID retorna 200;
- ID inexistente retorna 404.

## US07 - Atualizar configuração

Como gestor, quero alterar horário, capacidade ou tempo médio.

CritÃ©rios:

- PUT /api/configuracoes-operacionais/{id};
- não permitir duas configurações ativas para a mesma unidade e dia;
- dados inválidos retornam 400;
- sucesso retorna 204.

## US08 - Excluir configuração

Como gestor, quero remover uma configuração incorreta.

Critérios:

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
