using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDGShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class _10thInter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BuyGetFreeDiscountTotal",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyGetFreeDiscountTotal",
                table: "Cart");
        }
    }
}
