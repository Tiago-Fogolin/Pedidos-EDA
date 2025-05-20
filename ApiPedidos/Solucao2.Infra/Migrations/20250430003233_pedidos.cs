using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucao2.Infra.Migrations
{
    /// <inheritdoc />
    public partial class pedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdProdutos = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnderecoEntg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Despachado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
