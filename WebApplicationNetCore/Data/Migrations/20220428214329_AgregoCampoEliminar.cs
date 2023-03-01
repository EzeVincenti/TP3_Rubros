using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNetCore.Data.Migrations
{
    public partial class AgregoCampoEliminar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Rubro",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Rubro");
        }
    }
}
