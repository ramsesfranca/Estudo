using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RF.Estudo.Infrastructure.Migrations
{
    public partial class Criar_Tabela_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Rg = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Cep = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraModificado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TipoTelefone = table.Column<int>(type: "int", unicode: false, maxLength: 9, nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
