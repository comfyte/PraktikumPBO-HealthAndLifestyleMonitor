using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAndLifestyleMonitor.Migrations
{
    public partial class TestMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaftarTekananDarah",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TanggalWaktu = table.Column<string>(nullable: true),
                    Sistolik = table.Column<int>(nullable: false),
                    Diastolik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaftarTekananDarah", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaftarTekananDarah");
        }
    }
}
