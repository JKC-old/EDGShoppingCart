using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDGShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class _8thIter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromotionFlag",
                table: "Discount",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionFlag",
                table: "Discount");
        }
    }
}
