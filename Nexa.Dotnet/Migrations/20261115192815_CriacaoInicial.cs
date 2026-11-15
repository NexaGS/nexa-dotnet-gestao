using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Dotnet.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_unidades_gestao",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_unidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    codigo_cnes_unidade = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ativa = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    logradouro = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    numero = table.Column<string>(type: "NVARCHAR2(6)", maxLength: 6, nullable: true),
                    complemento = table.Column<string>(type: "NVARCHAR2(35)", maxLength: 35, nullable: true),
                    bairro = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    cidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    cep = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_unidades_gestao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_configuracao_operacional",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    unidade_saude_id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dia_semana = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    hora_abertura = table.Column<string>(type: "NVARCHAR2(48)", nullable: false),
                    hora_fechamento = table.Column<string>(type: "NVARCHAR2(48)", nullable: false),
                    capacidade_diaria = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    tempo_medio_minutos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    configuracao_ativa = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_configuracao_operacional", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_configuracao_operacional_tb_unidades_gestao_unidade_saude_id",
                        column: x => x.unidade_saude_id,
                        principalTable: "tb_unidades_gestao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_configuracao_operacional_unidade_saude_id",
                table: "tb_configuracao_operacional",
                column: "unidade_saude_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_configuracao_operacional");

            migrationBuilder.DropTable(
                name: "tb_unidades_gestao");
        }
    }
}
