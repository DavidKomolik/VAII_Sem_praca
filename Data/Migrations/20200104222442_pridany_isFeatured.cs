using Microsoft.EntityFrameworkCore.Migrations;

namespace Semestralna_praca_VAII.Data.Migrations
{
    public partial class pridany_isFeatured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFeatured",
                table: "Event",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFeatured",
                table: "Event");
        }
    }
}
