using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFMS_v2_app.Migrations
{
    public partial class canBeNullForCVR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPR",
                table: "Citizens");

            migrationBuilder.AddColumn<long>(
                name: "CVR",
                table: "Citizens",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVR",
                table: "Citizens");

            migrationBuilder.AddColumn<long>(
                name: "CPR",
                table: "Citizens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
