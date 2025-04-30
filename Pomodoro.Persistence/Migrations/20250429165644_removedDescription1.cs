using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedDescription1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroTask_Users_UserId",
                table: "PomodoroTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PomodoroTask",
                table: "PomodoroTask");

            migrationBuilder.RenameTable(
                name: "PomodoroTask",
                newName: "PomodoroTasks");

            migrationBuilder.RenameIndex(
                name: "IX_PomodoroTask_UserId",
                table: "PomodoroTasks",
                newName: "IX_PomodoroTasks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PomodoroTasks",
                table: "PomodoroTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroTasks_Users_UserId",
                table: "PomodoroTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroTasks_Users_UserId",
                table: "PomodoroTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PomodoroTasks",
                table: "PomodoroTasks");

            migrationBuilder.RenameTable(
                name: "PomodoroTasks",
                newName: "PomodoroTask");

            migrationBuilder.RenameIndex(
                name: "IX_PomodoroTasks_UserId",
                table: "PomodoroTask",
                newName: "IX_PomodoroTask_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PomodoroTask",
                table: "PomodoroTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroTask_Users_UserId",
                table: "PomodoroTask",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
