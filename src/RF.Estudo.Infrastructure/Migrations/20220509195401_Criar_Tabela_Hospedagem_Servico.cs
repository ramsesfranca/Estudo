using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RF.Estudo.Infrastructure.Migrations
{
    public partial class Criar_Tabela_Hospedagem_Servico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospedagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdPessoas = table.Column<int>(type: "int", nullable: false),
                    Desconto = table.Column<int>(type: "int", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraModificado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospedagens_Chales_ChaleId",
                        column: x => x.ChaleId,
                        principalTable: "Chales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospedagens_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospedagem_Servico",
                columns: table => new
                {
                    DataServico = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    HospedagemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorServico = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedagem_Servico", x => x.DataServico);
                    table.ForeignKey(
                        name: "FK_Hospedagem_Servico_Hospedagens_HospedagemId",
                        column: x => x.HospedagemId,
                        principalTable: "Hospedagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospedagem_Servico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospedagem_Servico_HospedagemId",
                table: "Hospedagem_Servico",
                column: "HospedagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospedagem_Servico_ServicoId",
                table: "Hospedagem_Servico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospedagens_ChaleId",
                table: "Hospedagens",
                column: "ChaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospedagens_ClienteId",
                table: "Hospedagens",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospedagem_Servico");

            migrationBuilder.DropTable(
                name: "Hospedagens");
        }
    }
}
