using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAndLifestyleMonitor.Migrations
{
    public partial class TestMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tanggal",
                table: "DaftarAirMinum",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tanggal",
                table: "DaftarAirMinum");
        }
    }
}
