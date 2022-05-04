using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazyn.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Akcesoria",
                columns: table => new
                {
                    AkcesoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akcesoria", x => x.AkcesoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Plyty",
                columns: table => new
                {
                    PlytyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plyty", x => x.PlytyID);
                });

            migrationBuilder.CreateTable(
                name: "Prowadnice",
                columns: table => new
                {
                    ProwadniceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Dlugosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Samodomyk = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prowadnice", x => x.ProwadniceID);
                });

            migrationBuilder.CreateTable(
                name: "Uchwyty",
                columns: table => new
                {
                    UchwytID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Rozstaw = table.Column<int>(type: "int", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uchwyty", x => x.UchwytID);
                });

            migrationBuilder.CreateTable(
                name: "Zawiasy",
                columns: table => new
                {
                    ZawiasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Kat_Otwarcia = table.Column<int>(type: "int", nullable: false),
                    Hamulec = table.Column<bool>(type: "bit", nullable: false),
                    Sprezyna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zawiasy", x => x.ZawiasID);
                });

            migrationBuilder.CreateTable(
                name: "RozmiaryPlyt",
                columns: table => new
                {
                    RozmiarPlytyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dlugosc = table.Column<int>(type: "int", nullable: false),
                    Szerokosc = table.Column<int>(type: "int", nullable: false),
                    Grubosc = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    PlytaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RozmiaryPlyt", x => x.RozmiarPlytyID);
                    table.ForeignKey(
                        name: "FK_RozmiaryPlyt_Plyty_PlytaID",
                        column: x => x.PlytaID,
                        principalTable: "Plyty",
                        principalColumn: "PlytyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RozmiaryPlyt_PlytaID",
                table: "RozmiaryPlyt",
                column: "PlytaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Akcesoria");

            migrationBuilder.DropTable(
                name: "Prowadnice");

            migrationBuilder.DropTable(
                name: "RozmiaryPlyt");

            migrationBuilder.DropTable(
                name: "Uchwyty");

            migrationBuilder.DropTable(
                name: "Zawiasy");

            migrationBuilder.DropTable(
                name: "Plyty");
        }
    }
}
