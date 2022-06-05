using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class ReplacedScheduleDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Schedules_ScheduleDay",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Breaks_Schedules_ScheduleDay",
                table: "Breaks");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Schedules",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ScheduleDay",
                table: "Breaks",
                newName: "DayDate");

            migrationBuilder.RenameIndex(
                name: "IX_Breaks_ScheduleDay",
                table: "Breaks",
                newName: "IX_Breaks_DayDate");

            migrationBuilder.RenameColumn(
                name: "ScheduleDay",
                table: "Bookings",
                newName: "DayDate");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ScheduleDay",
                table: "Bookings",
                newName: "IX_Bookings_DayDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "Breaks",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "Bookings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Schedules_DayDate",
                table: "Bookings",
                column: "DayDate",
                principalTable: "Schedules",
                principalColumn: "Date");

            migrationBuilder.AddForeignKey(
                name: "FK_Breaks_Schedules_DayDate",
                table: "Breaks",
                column: "DayDate",
                principalTable: "Schedules",
                principalColumn: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Schedules_DayDate",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Breaks_Schedules_DayDate",
                table: "Breaks");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Schedules",
                newName: "Day");

            migrationBuilder.RenameColumn(
                name: "DayDate",
                table: "Breaks",
                newName: "ScheduleDay");

            migrationBuilder.RenameIndex(
                name: "IX_Breaks_DayDate",
                table: "Breaks",
                newName: "IX_Breaks_ScheduleDay");

            migrationBuilder.RenameColumn(
                name: "DayDate",
                table: "Bookings",
                newName: "ScheduleDay");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_DayDate",
                table: "Bookings",
                newName: "IX_Bookings_ScheduleDay");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "Breaks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Schedules_ScheduleDay",
                table: "Bookings",
                column: "ScheduleDay",
                principalTable: "Schedules",
                principalColumn: "Day");

            migrationBuilder.AddForeignKey(
                name: "FK_Breaks_Schedules_ScheduleDay",
                table: "Breaks",
                column: "ScheduleDay",
                principalTable: "Schedules",
                principalColumn: "Day");
        }
    }
}
