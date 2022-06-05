using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class FixedErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Schedules_DayDate",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Breaks");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DayDate",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DayDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Days");

            migrationBuilder.AddColumn<int>(
                name: "TimeBlockId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "Date");

            migrationBuilder.CreateTable(
                name: "TimeBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    End = table.Column<TimeSpan>(type: "time", nullable: false),
                    Day = table.Column<DateTime>(type: "date", nullable: false),
                    DayDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeBlocks_Days_DayDate",
                        column: x => x.DayDate,
                        principalTable: "Days",
                        principalColumn: "Date");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeBlocks_DayDate",
                table: "TimeBlocks",
                column: "DayDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeBlocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "TimeBlockId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Days",
                newName: "Schedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "Bookings",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DayDate",
                table: "Bookings",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "End",
                table: "Schedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Start",
                table: "Schedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Date");

            migrationBuilder.CreateTable(
                name: "Breaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "date", nullable: false),
                    DayDate = table.Column<DateTime>(type: "date", nullable: true),
                    End = table.Column<TimeSpan>(type: "time", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breaks_Schedules_DayDate",
                        column: x => x.DayDate,
                        principalTable: "Schedules",
                        principalColumn: "Date");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DayDate",
                table: "Bookings",
                column: "DayDate");

            migrationBuilder.CreateIndex(
                name: "IX_Breaks_DayDate",
                table: "Breaks",
                column: "DayDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Schedules_DayDate",
                table: "Bookings",
                column: "DayDate",
                principalTable: "Schedules",
                principalColumn: "Date");
        }
    }
}
