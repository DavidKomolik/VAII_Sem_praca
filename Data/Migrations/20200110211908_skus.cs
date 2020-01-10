using Microsoft.EntityFrameworkCore.Migrations;

namespace Semestralna_praca_VAII.Data.Migrations
{
    public partial class skus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shoppingHistoryID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userCartID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_shoppingHistoryID",
                table: "AspNetUsers",
                column: "shoppingHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_userCartID",
                table: "AspNetUsers",
                column: "userCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingHistory_shoppingHistoryID",
                table: "AspNetUsers",
                column: "shoppingHistoryID",
                principalTable: "ShoppingHistory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cart_userCartID",
                table: "AspNetUsers",
                column: "userCartID",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingHistory_shoppingHistoryID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cart_userCartID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_shoppingHistoryID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_userCartID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "shoppingHistoryID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userCartID",
                table: "AspNetUsers");
        }
    }
}
