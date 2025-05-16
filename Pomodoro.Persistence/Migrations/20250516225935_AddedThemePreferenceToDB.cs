using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedThemePreferenceToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "UserSettings");
        }
    }
}
