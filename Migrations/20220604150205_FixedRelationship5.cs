using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class FixedRelationship5 : Migration
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
                name: "DateId",
                table: "Timeblocks",
                newName: "Day");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_Day",
                table: "Timeblocks");

            migrationBuilder.DropIndex(
                name: "IX_Timeblocks_Day",
                table: "Timeblocks");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Timeblocks",
                newName: "DateId");

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
