using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazyn.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Akcesoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akcesoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plyty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prowadnice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Prowadnice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uchwyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Uchwyty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zawiasy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    KatOtwarcia = table.Column<int>(type: "int", nullable: false),
                    Hamulec = table.Column<bool>(type: "bit", nullable: false),
                    Sprezyna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zawiasy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RozmiaryPlyt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dlugosc = table.Column<int>(type: "int", nullable: false),
                    Szerokosc = table.Column<int>(type: "int", nullable: false),
                    Grubosc = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    PlytaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RozmiaryPlyt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RozmiaryPlyt_Plyty_PlytaID",
                        column: x => x.PlytaID,
                        principalTable: "Plyty",
                        principalColumn: "Id",
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
