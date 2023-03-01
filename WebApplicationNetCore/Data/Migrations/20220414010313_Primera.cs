using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNetCore.Data.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rubro",
                columns: table => new
                {
                    RubroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubro", x => x.RubroID);
                });

            migrationBuilder.CreateTable(
                name: "Subrubro",
                columns: table => new
                {
                    SubrubroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    RubroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subrubro", x => x.SubrubroID);
                    table.ForeignKey(
                        name: "FK_Subrubro_Rubro_RubroID",
                        column: x => x.RubroID,
                        principalTable: "Rubro",
                        principalColumn: "RubroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    ArticuloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    UltAct = table.Column<DateTime>(nullable: false),
                    PrecioCosto = table.Column<decimal>(nullable: false),
                    PorcentajeGanancia = table.Column<decimal>(nullable: false),
                    PrecioVenta = table.Column<decimal>(nullable: false),
                    SubrubroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.ArticuloID);
                    table.ForeignKey(
                        name: "FK_Articulo_Subrubro_SubrubroID",
                        column: x => x.SubrubroID,
                        principalTable: "Subrubro",
                        principalColumn: "SubrubroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_SubrubroID",
                table: "Articulo",
                column: "SubrubroID");

            migrationBuilder.CreateIndex(
                name: "IX_Subrubro_RubroID",
                table: "Subrubro",
                column: "RubroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Subrubro");

            migrationBuilder.DropTable(
                name: "Rubro");
        }
    }
}
