using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFMS_WebAPI.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Facilities");

            migrationBuilder.AddColumn<long>(
                name: "Latitude",
                table: "Facilities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Longitude",
                table: "Facilities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Facilities");

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
