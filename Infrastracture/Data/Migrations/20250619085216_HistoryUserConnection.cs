using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Migrations
{
    /// <inheritdoc />
    public partial class HistoryUserConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "History",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                table: "History",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Users_UserId",
                table: "History",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Users_UserId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_UserId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "History");
        }
    }
}
