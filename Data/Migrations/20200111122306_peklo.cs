using Microsoft.EntityFrameworkCore.Migrations;

namespace Semestralna_praca_VAII.Data.Migrations
{
    public partial class peklo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addedItemID = table.Column<int>(nullable: false),
                    amount = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    CartID = table.Column<int>(nullable: true),
                    ShoppingHistoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_ShoppingHistory_ShoppingHistoryID",
                        column: x => x.ShoppingHistoryID,
                        principalTable: "ShoppingHistory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_Event_addedItemID",
                        column: x => x.addedItemID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartID",
                table: "CartItem",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingHistoryID",
                table: "CartItem",
                column: "ShoppingHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_addedItemID",
                table: "CartItem",
                column: "addedItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");
        }
    }
}
