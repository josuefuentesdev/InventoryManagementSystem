using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Infrastructure.Persistence.Migrations
{
    public partial class addRegionPropertyPersonItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "PersonItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "PersonItems");
        }
    }
}
