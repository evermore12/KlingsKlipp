using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class AddedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_DayDate",
                table: "Timeblocks");

            migrationBuilder.DropIndex(
                name: "IX_Timeblocks_DayDate",
                table: "Timeblocks");

            migrationBuilder.DropColumn(
                name: "DayDate",
                table: "Timeblocks");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Timeblocks",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "TimeBlockId",
                table: "Bookings",
                newName: "TimeblockId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeblocks_Date",
                table: "Timeblocks",
                column: "Date");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_Date",
                table: "Timeblocks",
                column: "Date",
                principalTable: "Days",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_Date",
                table: "Timeblocks");

            migrationBuilder.DropIndex(
                name: "IX_Timeblocks_Date",
                table: "Timeblocks");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Timeblocks",
                newName: "Day");

            migrationBuilder.RenameColumn(
                name: "TimeblockId",
                table: "Bookings",
                newName: "TimeBlockId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayDate",
                table: "Timeblocks",
                type: "date",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timeblocks_DayDate",
                table: "Timeblocks",
                column: "DayDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_DayDate",
                table: "Timeblocks",
                column: "DayDate",
                principalTable: "Days",
                principalColumn: "Date");
        }
    }
}
