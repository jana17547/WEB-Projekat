using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoSkolaID",
                table: "KandidatiKategorije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AutoSkola",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoSkola", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiKategorije_AutoSkolaID",
                table: "KandidatiKategorije",
                column: "AutoSkolaID");

            migrationBuilder.AddForeignKey(
                name: "FK_KandidatiKategorije_AutoSkola_AutoSkolaID",
                table: "KandidatiKategorije",
                column: "AutoSkolaID",
                principalTable: "AutoSkola",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KandidatiKategorije_AutoSkola_AutoSkolaID",
                table: "KandidatiKategorije");

            migrationBuilder.DropTable(
                name: "AutoSkola");

            migrationBuilder.DropIndex(
                name: "IX_KandidatiKategorije_AutoSkolaID",
                table: "KandidatiKategorije");

            migrationBuilder.DropColumn(
                name: "AutoSkolaID",
                table: "KandidatiKategorije");
        }
    }
}
