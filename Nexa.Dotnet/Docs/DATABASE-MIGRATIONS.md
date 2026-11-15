# 🗄️ Oracle Database & Entity Framework Core Migrations

Guia oficial de provisionamento relacional, versionamento Code-First e compatibilidade com o **Oracle Database 19c (FIAP)** para a API **Nexa .NET** (Global Solution 2026/2).

---

## 🏛️ 1. Visão Geral da Estrutura Relacional

O schema do banco de dados é provisionado exclusivamente via **Entity Framework Core Migrations** (Code-First), garantindo rastreabilidade, repetibilidade e conformidade com o modelo relacional 1:N:

### Tabelas Provisionadas:
1. **`tb_unidades_gestao`:**
   - Representa as Unidades Básicas de Saúde (UBS) cadastradas no CNES.
   - Chave Primária: `id` (NUMBER com auto-incremento identity).
   - Endereço embutido via Value Object (`[Owned]`): `logradouro`, `numero`, `complemento`, `bairro`, `cidade`, `estado`, `cep`.
   - Status da Unidade: `ativa` (`NUMBER(1)`).

2. **`tb_configuracao_operacional`:**
   - Parametrização semanal de dias, horários de funcionamento, teto de capacidade diária e tempo médio estimado de consulta.
   - Chave Primária: `id` (NUMBER com auto-incremento identity).
   - Chave Estrangeira: `unidade_saude_id` apontando para `tb_unidades_gestao(id)` com `ON DELETE CASCADE`.
   - Status da Configuração: `configuracao_ativa` (`NUMBER(1)`).

---

## ⚠️ 2. Compatibilidade com Oracle 19c (FIAP) & Mapeamento de Booleans

### A. A Limitação Histórica do Oracle 19c
* O banco corporativo disponibilizado na infraestrutura acadêmica da FIAP (`oracle.fiap.com.br`) opera na versão **Oracle Database 19c Enterprise Edition**.
* Antes da versão **23c**, o dialeto SQL do Oracle **NÃO possui suporte ao tipo de dados `BOOLEAN`** em comandos DDL (`CREATE TABLE`, `ALTER TABLE`). O tipo `BOOLEAN` existia exclusivamente no ambiente de execução procedural PL/SQL, mas não na engine relacional SQL.
* Por padrão, versões recentes do driver `Oracle.EntityFrameworkCore` assumem a versão 23c como alvo padrão e tentam criar colunas `type: "BOOLEAN"`, resultando em falhas de execução.

### B. Convenção Corporativa: Booleans como `NUMBER(1)`
Para compatibilidade universal e estabilidade no Oracle 19c, todos os campos booleanos devem ser persistidos explicitamente como **numéricos de 1 dígito (`NUMBER(1)`)**:
* `1` representa `true` (ativo / habilitado);
* `0` representa `false` (inativo / desabilitado).

### C. Configuração no Código C#

#### 1. Data Annotations nas Entidades
No arquivo [`UnidadeSaudeGestao.cs`](file:///C:/Users/Paulo/Fiap/2tdsps/GlobalSolution2026/AdvancedBusinessDevelopment/nexa-dotnet/Nexa.Dotnet/Models/UnidadeSaudeGestao.cs):
```csharp
[Column("ativa", TypeName = "NUMBER(1)")]
public bool Ativa { get; set; } = true;
```

No arquivo [`ConfiguracaoOperacional.cs`](file:///C:/Users/Paulo/Fiap/2tdsps/GlobalSolution2026/AdvancedBusinessDevelopment/nexa-dotnet/Nexa.Dotnet/Models/ConfiguracaoOperacional.cs):
```csharp
[Column("configuracao_ativa", TypeName = "NUMBER(1)")]
public bool ConfiguracaoAtiva { get; set; } = true;
```

#### 2. Compatibilidade no `Program.cs` (Recomendado)
Instrui o provedor EF Core a gerar SQL estritamente compatível com o Oracle 19c:
```csharp
var stringConexao = builder.Configuration.GetConnectionString("OracleConnection");

builder.Services.AddDbContext<NexaDbContext>(options =>
    options.UseOracle(stringConexao, b => b.UseOracleSQLCompatibility("19")));
```

---

## 🚨 3. Diagnóstico e Resolução do Erro `ORA-00902`

### Sintoma
Ao disparar `dotnet ef database update`, o terminal exibe a exceção do Oracle:
```text
ORA-00902: tipo de dados invalido.
ORA-06512: em line 2
```

### Causa
A migration atual foi gerada com a anotação `table.Column<bool>(type: "BOOLEAN", ...)` no arquivo de migração. Ao tentar executar o `CREATE TABLE` no Oracle 19c, o compilador SQL do Oracle rejeita a instrução DDL.

### Passo a Passo de Resolução (Reset Limpo da Migration)

1. **Acessar a pasta do projeto .NET:**
   ```powershell
   cd Nexa.Dotnet
   ```

2. **Remover a migration com tipo inválido:**
   ```powershell
   dotnet ef migrations remove
   ```

3. **Verificar se as models possuem `TypeName = "NUMBER(1)"`:**
   Garanta que `UnidadeSaudeGestao.cs` e `ConfiguracaoOperacional.cs` possuam o atributo `[Column("...", TypeName = "NUMBER(1)")]`.

4. **Recriar a migration limpa:**
   ```powershell
   dotnet ef migrations add CriacaoInicial
   ```

5. **Aplicar a migration no Oracle com sucesso:**
   ```powershell
   dotnet ef database update
   ```

---

## 💻 4. Catálogo de Comandos Úteis do EF Core

| Comando | Descrição |
| :--- | :--- |
| `dotnet ef migrations add <Nome>` | Cria uma nova classe de migração comparando o modelo C# com o snapshot. |
| `dotnet ef migrations remove` | Remove a última migração criada (apenas se ainda não aplicada no banco). |
| `dotnet ef migrations list` | Lista todas as migrações criadas e indica quais já foram aplicadas. |
| `dotnet ef database update` | Aplica todas as migrações pendentes no banco de dados configurado. |
| `dotnet ef migrations script` | Gera o script SQL puro equivalente às migrations para auditoria. |

---

## 🔒 5. Regras de Ouro e Segurança de Dados

1. **Proibido DDL Manual:** Nenhuma tabela, coluna ou chave primária/estrangeira deve ser criada manualmente no SQL Developer. Toda a estrutura do banco deve ser governada pelo Code-First do EF Core.
2. **Versionamento de Migrations:** A pasta `Nexa.Dotnet/Migrations/` deve ser obrigatoriamente commitada no Git, pois ela mantém o histórico evolutivo da base de dados.
3. **Sigilo de Credenciais:** Nunca versione senhas, connection strings, arquivos `.env` ou dumps no repositório. O segredo deve ser injetado via **Secret Manager (`dotnet user-secrets`)** em ambiente de desenvolvimento:
   ```powershell
   dotnet user-secrets set "ConnectionStrings:OracleConnection" "User Id=RMXXXXXX;Password=suaSenhaSegura;Data Source=oracle.fiap.com.br:1521/ORCL"
   ```
4. **Isolamento de Domínio:** O schema do .NET (`tb_unidades_gestao` e `tb_configuracao_operacional`) atua no back-office administrativo, não devendo colidir nem misturar entidades com o módulo Spring Boot de atendimento.

---

## ✅ 6. Checklist de Validação Pós-Migração

Execute as etapas abaixo para certificar que o banco está 100% íntegro:

- [ ] Connection string configurada via `dotnet user-secrets`.
- [ ] Migration `CriacaoInicial` gerada com colunas `NUMBER(1)` para os booleans.
- [ ] `dotnet ef database update` executado com status de sucesso.
- [ ] Conferência visual no Oracle (DBeaver, SQL Developer ou VS Code Database Tool):
  - [ ] Tabela `TB_UNIDADES_GESTAO` criada;
  - [ ] Tabela `TB_CONFIGURACAO_OPERACIONAL` criada;
  - [ ] Colunas `ATIVA` e `CONFIGURACAO_ATIVA` criadas como `NUMBER(1)`;
  - [ ] Foreign Key `FK_TB_CONFIGURACAO_OPERACIONAL_TB_UNIDADES_GESTAO` criada;
  - [ ] Tabela de controle `__EFMigrationsHistory` criada.
- [ ] Subir a API (`dotnet run`) e realizar o cadastro inicial de teste via Swagger UI.
