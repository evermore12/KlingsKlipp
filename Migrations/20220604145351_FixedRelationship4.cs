using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class FixedRelationship4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_DateId",
                table: "Timeblocks");

            migrationBuilder.DropIndex(
                name: "IX_Timeblocks_DateId",
                table: "Timeblocks");

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
                name: "IX_Timeblocks_DateId",
                table: "Timeblocks",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_DateId",
                table: "Timeblocks",
                column: "DateId",
                principalTable: "Days",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
