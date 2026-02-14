using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Migrations
{
    /// <inheritdoc />
    public partial class ProductDetailsDeletedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hidden",
                table: "Products",
                newName: "Deleted");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ProductPhotos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ProductDescriptions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ProductPhotos");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ProductDescriptions");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Products",
                newName: "Hidden");
        }
    }
}
