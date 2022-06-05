using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class RenamedTimeblock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlocks_Days_DayDate",
                table: "TimeBlocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeBlocks",
                table: "TimeBlocks");

            migrationBuilder.RenameTable(
                name: "TimeBlocks",
                newName: "Timeblocks");

            migrationBuilder.RenameIndex(
                name: "IX_TimeBlocks_DayDate",
                table: "Timeblocks",
                newName: "IX_Timeblocks_DayDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timeblocks",
                table: "Timeblocks",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timeblocks",
                table: "Timeblocks");

            migrationBuilder.RenameTable(
                name: "Timeblocks",
                newName: "TimeBlocks");

            migrationBuilder.RenameIndex(
                name: "IX_Timeblocks_DayDate",
                table: "TimeBlocks",
                newName: "IX_TimeBlocks_DayDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeBlocks",
                table: "TimeBlocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlocks_Days_DayDate",
                table: "TimeBlocks",
                column: "DayDate",
                principalTable: "Days",
                principalColumn: "Date");
        }
    }
}
