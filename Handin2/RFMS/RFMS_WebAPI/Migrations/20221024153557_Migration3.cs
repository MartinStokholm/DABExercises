using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFMS_WebAPI.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CPR",
                table: "Citizens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookingCitizen",
                columns: table => new
                {
                    BookingsId = table.Column<long>(type: "bigint", nullable: false),
                    CitizensId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCitizen", x => new { x.BookingsId, x.CitizensId });
                    table.ForeignKey(
                        name: "FK_BookingCitizen_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingCitizen_Citizens_CitizensId",
                        column: x => x.CitizensId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCitizen_CitizensId",
                table: "BookingCitizen",
                column: "CitizensId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCitizen");

            migrationBuilder.DropColumn(
                name: "CPR",
                table: "Citizens");
        }
    }
}
