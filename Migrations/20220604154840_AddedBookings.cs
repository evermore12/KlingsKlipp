using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class AddedBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeblockId",
                table: "Bookings",
                column: "TimeblockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Timeblocks_TimeblockId",
                table: "Bookings",
                column: "TimeblockId",
                principalTable: "Timeblocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Timeblocks_TimeblockId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TimeblockId",
                table: "Bookings");
        }
    }
}
