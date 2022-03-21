using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spojevi_Kandidat_KandidatID",
                table: "Spojevi");

            migrationBuilder.DropForeignKey(
                name: "FK_Spojevi_Kategorije_KategorijaID",
                table: "Spojevi");

            migrationBuilder.DropForeignKey(
                name: "FK_Spojevi_Polaganja_PolaganjeID",
                table: "Spojevi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spojevi",
                table: "Spojevi");

            migrationBuilder.DropColumn(
                name: "IDKandidata",
                table: "Polaganja");

            migrationBuilder.DropColumn(
                name: "Kategorija",
                table: "Polaganja");

            migrationBuilder.DropColumn(
                name: "Poeni",
                table: "Polaganja");

            migrationBuilder.RenameTable(
                name: "Spojevi",
                newName: "KandidatiKategorije");

            migrationBuilder.RenameIndex(
                name: "IX_Spojevi_PolaganjeID",
                table: "KandidatiKategorije",
                newName: "IX_KandidatiKategorije_PolaganjeID");

            migrationBuilder.RenameIndex(
                name: "IX_Spojevi_KategorijaID",
                table: "KandidatiKategorije",
                newName: "IX_KandidatiKategorije_KategorijaID");

            migrationBuilder.RenameIndex(
                name: "IX_Spojevi_KandidatID",
                table: "KandidatiKategorije",
                newName: "IX_KandidatiKategorije_KandidatID");

            migrationBuilder.AddColumn<int>(
                name: "Poeni",
                table: "KandidatiKategorije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KandidatiKategorije",
                table: "KandidatiKategorije",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KandidatiKategorije_Kandidat_KandidatID",
                table: "KandidatiKategorije",
                column: "KandidatID",
                principalTable: "Kandidat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KandidatiKategorije_Kategorije_KategorijaID",
                table: "KandidatiKategorije",
                column: "KategorijaID",
                principalTable: "Kategorije",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KandidatiKategorije_Polaganja_PolaganjeID",
                table: "KandidatiKategorije",
                column: "PolaganjeID",
                principalTable: "Polaganja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KandidatiKategorije_Kandidat_KandidatID",
                table: "KandidatiKategorije");

            migrationBuilder.DropForeignKey(
                name: "FK_KandidatiKategorije_Kategorije_KategorijaID",
                table: "KandidatiKategorije");

            migrationBuilder.DropForeignKey(
                name: "FK_KandidatiKategorije_Polaganja_PolaganjeID",
                table: "KandidatiKategorije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KandidatiKategorije",
                table: "KandidatiKategorije");

            migrationBuilder.DropColumn(
                name: "Poeni",
                table: "KandidatiKategorije");

            migrationBuilder.RenameTable(
                name: "KandidatiKategorije",
                newName: "Spojevi");

            migrationBuilder.RenameIndex(
                name: "IX_KandidatiKategorije_PolaganjeID",
                table: "Spojevi",
                newName: "IX_Spojevi_PolaganjeID");

            migrationBuilder.RenameIndex(
                name: "IX_KandidatiKategorije_KategorijaID",
                table: "Spojevi",
                newName: "IX_Spojevi_KategorijaID");

            migrationBuilder.RenameIndex(
                name: "IX_KandidatiKategorije_KandidatID",
                table: "Spojevi",
                newName: "IX_Spojevi_KandidatID");

            migrationBuilder.AddColumn<int>(
                name: "IDKandidata",
                table: "Polaganja",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kategorija",
                table: "Polaganja",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Poeni",
                table: "Polaganja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spojevi",
                table: "Spojevi",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spojevi_Kandidat_KandidatID",
                table: "Spojevi",
                column: "KandidatID",
                principalTable: "Kandidat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spojevi_Kategorije_KategorijaID",
                table: "Spojevi",
                column: "KategorijaID",
                principalTable: "Kategorije",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spojevi_Polaganja_PolaganjeID",
                table: "Spojevi",
                column: "PolaganjeID",
                principalTable: "Polaganja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
