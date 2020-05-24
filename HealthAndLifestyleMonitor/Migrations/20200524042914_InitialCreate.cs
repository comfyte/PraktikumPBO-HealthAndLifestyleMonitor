using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAndLifestyleMonitor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaftarAirMinum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tanggal = table.Column<string>(nullable: true),
                    Waktu = table.Column<string>(nullable: true),
                    Jumlah = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaftarAirMinum", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "UserPrefs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    BoolValue = table.Column<bool>(nullable: false),
                    IntValue = table.Column<int>(nullable: false),
                    StringValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrefs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserPrefs",
                columns: new[] { "Id", "BoolValue", "IntValue", "Name", "StringValue" },
                values: new object[] { 1, false, 0, "temperature-unit", "C" });

            migrationBuilder.InsertData(
                table: "UserPrefs",
                columns: new[] { "Id", "BoolValue", "IntValue", "Name", "StringValue" },
                values: new object[] { 2, false, 0, "weather-location", "Yogyakarta" });

            migrationBuilder.InsertData(
                table: "UserPrefs",
                columns: new[] { "Id", "BoolValue", "IntValue", "Name", "StringValue" },
                values: new object[] { 3, false, 120, "sistolik-max", null });

            migrationBuilder.InsertData(
                table: "UserPrefs",
                columns: new[] { "Id", "BoolValue", "IntValue", "Name", "StringValue" },
                values: new object[] { 4, false, 80, "diastolik-max", null });

            migrationBuilder.InsertData(
                table: "UserPrefs",
                columns: new[] { "Id", "BoolValue", "IntValue", "Name", "StringValue" },
                values: new object[] { 5, false, 90, "sistolik-min", null });

            migrationBuilder.InsertData(
                table: "UserPrefs",
                columns: new[] { "Id", "BoolValue", "IntValue", "Name", "StringValue" },
                values: new object[] { 6, false, 60, "diastolik-min", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaftarAirMinum");

            migrationBuilder.DropTable(
                name: "DaftarJadwalObat");

            migrationBuilder.DropTable(
                name: "DaftarTekananDarah");

            migrationBuilder.DropTable(
                name: "UserPrefs");
        }
    }
}
