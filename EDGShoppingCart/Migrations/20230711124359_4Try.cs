using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDGShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class _4Try : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "CartItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Cart");
        }
    }
}
