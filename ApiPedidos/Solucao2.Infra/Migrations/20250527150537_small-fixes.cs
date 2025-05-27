using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucao2.Infra.Migrations
{
    /// <inheritdoc />
    public partial class smallfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EventosPedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventosPedidos");
        }
    }
}
