using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class UpdatedTimeToComplexTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Treatments"
            );
            migrationBuilder.DropColumn(
                name: "Start",
                table: "Days"
            );
            migrationBuilder.DropColumn(
                name: "End",
                table: "Days"
            );
            migrationBuilder.DropColumn(
                name: "End",
                table: "Bookings"
            );
            migrationBuilder.DropColumn(
                name: "Start",
                table: "Bookings"
            );


            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Treatments",
                type: "time"
            );
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Start",
                table: "Days",
                type: "datetimeoffset"
            );
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "End",
                table: "Days",
                type: "datetimeoffset"
            );
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Start",
                table: "Bookings",
                type: "datetimeoffset"
            );
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "End",
                table: "Bookings",
                type: "datetimeoffset"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Duration",
                table: "Treatments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<long>(
                name: "Start",
                table: "Days",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<long>(
                name: "End",
                table: "Days",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<long>(
                name: "Start",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<long>(
                name: "End",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
