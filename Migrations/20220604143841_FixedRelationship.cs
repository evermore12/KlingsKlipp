using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class FixedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_Date",
                table: "Timeblocks");

            migrationBuilder.DropIndex(
                name: "IX_Timeblocks_Date",
                table: "Timeblocks");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayDate",
                table: "Timeblocks",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Timeblocks_DayDate",
                table: "Timeblocks",
                column: "DayDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_DayDate",
                table: "Timeblocks",
                column: "DayDate",
                principalTable: "Days",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
