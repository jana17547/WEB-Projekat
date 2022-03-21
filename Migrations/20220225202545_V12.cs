using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KandidatiKategorije");

            migrationBuilder.DropTable(
                name: "Polaganja");

            migrationBuilder.DropColumn(
                name: "DatumUpisa",
                table: "Kandidat");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Kandidat");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "AutoSkola");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "AutoSkola");

            migrationBuilder.DropColumn(
                name: "Sifra",
                table: "AutoSkola");

            migrationBuilder.RenameColumn(
                name: "GodineStarosti",
                table: "Kategorije",
                newName: "AutoSkolaID");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Kategorije",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstruktorID",
                table: "Kategorije",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JMBG",
                table: "Kandidat",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "AutoSkola",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instruktor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruktor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polaze",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KandidatID = table.Column<int>(type: "int", nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: true),
                    Poeni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaze", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polaze_Kandidat_KandidatID",
                        column: x => x.KandidatID,
                        principalTable: "Kandidat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Polaze_Kategorije_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kategorije_AutoSkolaID",
                table: "Kategorije",
                column: "AutoSkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorije_InstruktorID",
                table: "Kategorije",
                column: "InstruktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Polaze_KandidatID",
                table: "Polaze",
                column: "KandidatID");

            migrationBuilder.CreateIndex(
                name: "IX_Polaze_KategorijaID",
                table: "Polaze",
                column: "KategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorije_AutoSkola_AutoSkolaID",
                table: "Kategorije",
                column: "AutoSkolaID",
                principalTable: "AutoSkola",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorije_Instruktor_InstruktorID",
                table: "Kategorije",
                column: "InstruktorID",
                principalTable: "Instruktor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorije_AutoSkola_AutoSkolaID",
                table: "Kategorije");

            migrationBuilder.DropForeignKey(
                name: "FK_Kategorije_Instruktor_InstruktorID",
                table: "Kategorije");

            migrationBuilder.DropTable(
                name: "Instruktor");

            migrationBuilder.DropTable(
                name: "Polaze");

            migrationBuilder.DropIndex(
                name: "IX_Kategorije_AutoSkolaID",
                table: "Kategorije");

            migrationBuilder.DropIndex(
                name: "IX_Kategorije_InstruktorID",
                table: "Kategorije");

            migrationBuilder.DropColumn(
                name: "InstruktorID",
                table: "Kategorije");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "AutoSkola");

            migrationBuilder.RenameColumn(
                name: "AutoSkolaID",
                table: "Kategorije",
                newName: "GodineStarosti");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Kategorije",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "JMBG",
                table: "Kandidat",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<string>(
                name: "DatumUpisa",
                table: "Kandidat",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Kandidat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "AutoSkola",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "AutoSkola",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sifra",
                table: "AutoSkola",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Polaganja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojPolaganja = table.Column<int>(type: "int", nullable: false),
                    DatumPolaganja = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaganja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KandidatiKategorije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoSkolaID = table.Column<int>(type: "int", nullable: true),
                    KandidatID = table.Column<int>(type: "int", nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: true),
                    Poeni = table.Column<int>(type: "int", nullable: false),
                    PolaganjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandidatiKategorije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KandidatiKategorije_AutoSkola_AutoSkolaID",
                        column: x => x.AutoSkolaID,
                        principalTable: "AutoSkola",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KandidatiKategorije_Kandidat_KandidatID",
                        column: x => x.KandidatID,
                        principalTable: "Kandidat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KandidatiKategorije_Kategorije_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KandidatiKategorije_Polaganja_PolaganjeID",
                        column: x => x.PolaganjeID,
                        principalTable: "Polaganja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiKategorije_AutoSkolaID",
                table: "KandidatiKategorije",
                column: "AutoSkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiKategorije_KandidatID",
                table: "KandidatiKategorije",
                column: "KandidatID");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiKategorije_KategorijaID",
                table: "KandidatiKategorije",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiKategorije_PolaganjeID",
                table: "KandidatiKategorije",
                column: "PolaganjeID");
        }
    }
}
