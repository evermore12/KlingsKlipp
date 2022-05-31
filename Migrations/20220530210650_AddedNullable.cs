using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class AddedNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlocks_Bookings_BookingId",
                table: "TimeBlocks");

            migrationBuilder.DropIndex(
                name: "IX_TimeBlocks_BookingId",
                table: "TimeBlocks");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "TimeBlocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_BookingId",
                table: "TimeBlocks",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlocks_Bookings_BookingId",
                table: "TimeBlocks",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlocks_Bookings_BookingId",
                table: "TimeBlocks");

            migrationBuilder.DropIndex(
                name: "IX_TimeBlocks_BookingId",
                table: "TimeBlocks");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "TimeBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_BookingId",
                table: "TimeBlocks",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlocks_Bookings_BookingId",
                table: "TimeBlocks",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
