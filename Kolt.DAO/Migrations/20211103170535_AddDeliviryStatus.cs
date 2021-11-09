using Microsoft.EntityFrameworkCore.Migrations;

namespace KOLT.DAL.Migrations
{
    public partial class AddDeliviryStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deliviry",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deliviry",
                table: "Orders");
        }
    }
}
