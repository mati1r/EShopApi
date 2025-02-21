using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalInfrastractureChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilterTypeId",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FilterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StorageFolder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StorageFileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubcategoryRefProductType",
                columns: table => new
                {
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoryRefProductType", x => new { x.SubcategoryId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_SubcategoryRefProductType_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubcategoryRefProductType_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_FilterTypeId",
                table: "ProductTypes",
                column: "FilterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcategoryRefProductType_ProductId",
                table: "SubcategoryRefProductType",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_FilterType_FilterTypeId",
                table: "ProductTypes",
                column: "FilterTypeId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_FilterType_FilterTypeId",
                table: "ProductTypes");

            migrationBuilder.DropTable(
                name: "FilterType");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "SubcategoryRefProductType");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_FilterTypeId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "FilterTypeId",
                table: "ProductTypes");
        }
    }
}
