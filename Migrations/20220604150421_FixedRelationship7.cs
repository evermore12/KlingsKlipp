using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class FixedRelationship7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_Day",
                table: "Timeblocks");

            migrationBuilder.DropIndex(
                name: "IX_Timeblocks_Day",
                table: "Timeblocks");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Timeblocks");

            migrationBuilder.CreateIndex(
                name: "IX_Timeblocks_DayId",
                table: "Timeblocks",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_DayId",
                table: "Timeblocks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_DayId",
                table: "Timeblocks");

            migrationBuilder.DropIndex(
                name: "IX_Timeblocks_DayId",
                table: "Timeblocks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "Timeblocks",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Timeblocks_Day",
                table: "Timeblocks",
                column: "Day");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_Day",
                table: "Timeblocks",
                column: "Day",
                principalTable: "Days",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
