using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDGShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class _9thIter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discount_Product_ProductId",
                table: "Discount");

            migrationBuilder.DropIndex(
                name: "IX_Discount_ProductId",
                table: "Discount");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "Discount");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Discount");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PromoFlag",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PromoFlag",
                table: "Product");

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "Discount",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Discount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Discount_ProductId",
                table: "Discount",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discount_Product_ProductId",
                table: "Discount",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
