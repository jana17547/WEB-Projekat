using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kandidat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumUpisa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Staus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kandidat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Cena = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    GodineStarosti = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polaganja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDKandidata = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Tip = table.Column<int>(type: "int", nullable: false),
                    Kategorija = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Poeni = table.Column<int>(type: "int", nullable: false),
                    DatumPolaganja = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaganja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spojevi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolaganjeID = table.Column<int>(type: "int", nullable: true),
                    KandidatID = table.Column<int>(type: "int", nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spojevi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Spojevi_Kandidat_KandidatID",
                        column: x => x.KandidatID,
                        principalTable: "Kandidat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spojevi_Kategorije_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spojevi_Polaganja_PolaganjeID",
                        column: x => x.PolaganjeID,
                        principalTable: "Polaganja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spojevi_KandidatID",
                table: "Spojevi",
                column: "KandidatID");

            migrationBuilder.CreateIndex(
                name: "IX_Spojevi_KategorijaID",
                table: "Spojevi",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Spojevi_PolaganjeID",
                table: "Spojevi",
                column: "PolaganjeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spojevi");

            migrationBuilder.DropTable(
                name: "Kandidat");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Polaganja");
        }
    }
}
