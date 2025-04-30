using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PomodoroTask");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PomodoroTask",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
