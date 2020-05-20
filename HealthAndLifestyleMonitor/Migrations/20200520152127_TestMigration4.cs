using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAndLifestyleMonitor.Migrations
{
    public partial class TestMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaftarJadwalObat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nama = table.Column<string>(nullable: true),
                    Deskripsi = table.Column<string>(nullable: true),
                    Waktu = table.Column<string>(nullable: true),
                    Hari = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaftarJadwalObat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaftarJadwalObat");
        }
    }
}
