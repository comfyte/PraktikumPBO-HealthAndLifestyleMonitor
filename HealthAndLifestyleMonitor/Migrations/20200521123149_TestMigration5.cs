using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAndLifestyleMonitor.Migrations
{
    public partial class TestMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "UserPrefs");
        }
    }
}
