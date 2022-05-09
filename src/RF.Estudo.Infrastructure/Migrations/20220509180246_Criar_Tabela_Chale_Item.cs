using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RF.Estudo.Infrastructure.Migrations
{
    public partial class Criar_Tabela_Chale_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Localizacao = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    ValorAltaEstacao = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorBaixaEstacao = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraModificado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Nome);
                });

            migrationBuilder.CreateTable(
                name: "ChaleItem",
                columns: table => new
                {
                    ChalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItensNome = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChaleItem", x => new { x.ChalesId, x.ItensNome });
                    table.ForeignKey(
                        name: "FK_ChaleItem_Chales_ChalesId",
                        column: x => x.ChalesId,
                        principalTable: "Chales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChaleItem_Items_ItensNome",
                        column: x => x.ItensNome,
                        principalTable: "Items",
                        principalColumn: "Nome",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChaleItem_ItensNome",
                table: "ChaleItem",
                column: "ItensNome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChaleItem");

            migrationBuilder.DropTable(
                name: "Chales");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
