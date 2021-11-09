using Microsoft.EntityFrameworkCore.Migrations;

namespace KOLT.DAL.Migrations
{
    public partial class ChangeNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Noomber",
                table: "Sellers",
                newName: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Sellers",
                newName: "Noomber");
        }
    }
}
