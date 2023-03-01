using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNetCore.Data.Migrations
{
    public partial class CampoEliminadoArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Articlo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Articlo");
        }
    }
}
