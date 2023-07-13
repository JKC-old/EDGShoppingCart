using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDGShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class _11thIter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SpendOverFiftyDiscountTotal",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpendOverFiftyDiscountTotal",
                table: "Cart");
        }
    }
}
