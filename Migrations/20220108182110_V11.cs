using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojPolaganja",
                table: "Polaganja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JMBG",
                table: "Kandidat",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sifra",
                table: "AutoSkola",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojPolaganja",
                table: "Polaganja");

            migrationBuilder.DropColumn(
                name: "JMBG",
                table: "Kandidat");

            migrationBuilder.DropColumn(
                name: "Sifra",
                table: "AutoSkola");
        }
    }
}
