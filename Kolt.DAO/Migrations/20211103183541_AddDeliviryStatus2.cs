using Microsoft.EntityFrameworkCore.Migrations;

namespace KOLT.DAL.Migrations
{
    public partial class AddDeliviryStatus2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deliviry",
                table: "Orders",
                newName: "Delivery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Delivery",
                table: "Orders",
                newName: "Deliviry");
        }
    }
}
