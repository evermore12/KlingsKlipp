using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class FixedRelationship3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_DayDate",
                table: "Timeblocks");

            migrationBuilder.RenameColumn(
                name: "DayDate",
                table: "Timeblocks",
                newName: "DateId");

            migrationBuilder.RenameIndex(
                name: "IX_Timeblocks_DayDate",
                table: "Timeblocks",
                newName: "IX_Timeblocks_DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_DateId",
                table: "Timeblocks",
                column: "DateId",
                principalTable: "Days",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeblocks_Days_DateId",
                table: "Timeblocks");

            migrationBuilder.RenameColumn(
                name: "DateId",
                table: "Timeblocks",
                newName: "DayDate");

            migrationBuilder.RenameIndex(
                name: "IX_Timeblocks_DateId",
                table: "Timeblocks",
                newName: "IX_Timeblocks_DayDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeblocks_Days_DayDate",
                table: "Timeblocks",
                column: "DayDate",
                principalTable: "Days",
                principalColumn: "Date",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
