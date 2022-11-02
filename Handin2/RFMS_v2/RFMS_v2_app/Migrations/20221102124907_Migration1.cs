using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFMS_v2_app.Migrations
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

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Facilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Facilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
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

            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
