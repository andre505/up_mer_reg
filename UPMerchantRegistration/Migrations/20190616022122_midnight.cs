using Microsoft.EntityFrameworkCore.Migrations;

namespace UPMerchantRegistration.Migrations
{
    public partial class midnight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lgacode",
                table: "lga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "lgacode",
                table: "lga",
                maxLength: 255,
                nullable: true);
        }
    }
}
