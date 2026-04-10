using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Migrations
{
    /// <inheritdoc />
    public partial class ModelValidationChangesAndHistoryAnonymusKeyField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnonymusUserAccessKey",
                table: "History",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhonePrefix",
                table: "Address",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnonymusUserAccessKey",
                table: "History");

            migrationBuilder.DropColumn(
                name: "PhonePrefix",
                table: "Address");
        }
    }
}
