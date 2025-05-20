using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucao2.Infra.Migrations
{
    /// <inheritdoc />
    public partial class NovosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.RenameColumn(
                name: "Despachado",
                table: "Pedidos",
                newName: "PedidoPrioritario");

            migrationBuilder.AddColumn<string>(
                name: "CanalVenda",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrega",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanalVenda",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataEntrega",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "PedidoPrioritario",
                table: "Pedidos",
                newName: "Despachado");

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remetente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });
        }
    }
}
