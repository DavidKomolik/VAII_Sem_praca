using Microsoft.EntityFrameworkCore.Migrations;

namespace Semestralna_praca_VAII.Data.Migrations
{
    public partial class zmenamena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Event_boughtEventID",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_boughtEventID",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "boughtEventID",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "addedItemID",
                table: "CartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_addedItemID",
                table: "CartItem",
                column: "addedItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Event_addedItemID",
                table: "CartItem",
                column: "addedItemID",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Event_addedItemID",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_addedItemID",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "addedItemID",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "boughtEventID",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_boughtEventID",
                table: "CartItem",
                column: "boughtEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Event_boughtEventID",
                table: "CartItem",
                column: "boughtEventID",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
