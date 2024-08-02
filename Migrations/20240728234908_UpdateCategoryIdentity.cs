using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleskBtocBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
               migrationBuilder.Sql(@"
                IF EXISTS (
                    SELECT * FROM sys.foreign_keys 
                    WHERE name = 'FK_Products_Categories_CategoryId'
                )
                BEGIN
                    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Categories_CategoryId];
                END
            ");


            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_categoryId");

            migrationBuilder.AddColumn<string>(
                name: "battery",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "connectivity",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contactNumber",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "express",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "features",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "freeShippingThreshold",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "frontCamera",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gtin",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "highlights",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "images",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "longDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "newCustomerCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "newCustomerDiscount",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "newCustomerLimit",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "originalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "os",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "performance",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "processor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ram",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "range",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "rating",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "rearCamera",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "resolution",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "reviewsCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "screen",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "security",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "shippingDestination",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "shippingDiscount",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "sim",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sku",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "storage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "weight",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "battery",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "connectivity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "contactNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "express",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "features",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "freeShippingThreshold",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "frontCamera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "gtin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "highlights",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "images",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "longDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "model",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "newCustomerCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "newCustomerDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "newCustomerLimit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "originalPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "os",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "performance",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "processor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ram",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "range",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "rearCamera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "resolution",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "reviewsCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "screen",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "security",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "shippingDestination",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "shippingDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "sim",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "sku",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "stock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "storage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
