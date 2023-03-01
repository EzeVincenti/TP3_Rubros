using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNetCore.Data.Migrations
{
    public partial class CreaSubRubro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubrubroID",
                table: "Subrubro",
                newName: "SubRubroID");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Subrubro",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Subrubro");

            migrationBuilder.RenameColumn(
                name: "SubRubroID",
                table: "Subrubro",
                newName: "SubrubroID");
        }
    }
}
