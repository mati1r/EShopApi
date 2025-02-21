using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalInfrastractureChangesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubcategoryRefProductType_Products_ProductId",
                table: "SubcategoryRefProductType");

            migrationBuilder.DropIndex(
                name: "IX_SubcategoryRefProductType_ProductId",
                table: "SubcategoryRefProductType");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SubcategoryRefProductType");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryRefProductType_ProductTypeId",
                table: "SubcategoryRefProductType",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubcategoryRefProductType_ProductTypes_ProductTypeId",
                table: "SubcategoryRefProductType",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubcategoryRefProductType_ProductTypes_ProductTypeId",
                table: "SubcategoryRefProductType");

            migrationBuilder.DropIndex(
                name: "IX_SubcategoryRefProductType_ProductTypeId",
                table: "SubcategoryRefProductType");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SubcategoryRefProductType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryRefProductType_ProductId",
                table: "SubcategoryRefProductType",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubcategoryRefProductType_Products_ProductId",
                table: "SubcategoryRefProductType",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
