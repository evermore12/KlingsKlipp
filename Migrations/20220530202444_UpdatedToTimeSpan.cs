using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class UpdatedToTimeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeBlocks_Days_DayId",
                table: "TimeBlocks");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_TimeBlocks_DayId",
                table: "TimeBlocks");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "TimeBlocks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimeBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimeBlocks");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "TimeBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_DayId",
                table: "TimeBlocks",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeBlocks_Days_DayId",
                table: "TimeBlocks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id");
        }
    }
}
