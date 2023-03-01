using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNetCore.Data.Migrations
{
    public partial class CreoArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Subrubro_SubrubroID",
                table: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "Articlo");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_SubrubroID",
                table: "Articlo",
                newName: "IX_Articlo_SubrubroID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articlo",
                table: "Articlo",
                column: "ArticuloID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articlo_Subrubro_SubrubroID",
                table: "Articlo",
                column: "SubrubroID",
                principalTable: "Subrubro",
                principalColumn: "SubRubroID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articlo_Subrubro_SubrubroID",
                table: "Articlo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articlo",
                table: "Articlo");

            migrationBuilder.RenameTable(
                name: "Articlo",
                newName: "Articulo");

            migrationBuilder.RenameIndex(
                name: "IX_Articlo_SubrubroID",
                table: "Articulo",
                newName: "IX_Articulo_SubrubroID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "ArticuloID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Subrubro_SubrubroID",
                table: "Articulo",
                column: "SubrubroID",
                principalTable: "Subrubro",
                principalColumn: "SubRubroID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
