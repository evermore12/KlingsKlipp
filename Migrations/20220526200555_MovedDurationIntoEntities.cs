using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class MovedDurationIntoEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Duration_DurationId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Duration_DurationId",
                table: "Days");

            migrationBuilder.DropTable(
                name: "Duration");

            migrationBuilder.DropIndex(
                name: "IX_Days_DurationId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DurationId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "End",
                table: "Days",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Start",
                table: "Days",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "End",
                table: "Bookings",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Start",
                table: "Bookings",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Duration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    End = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndUnix = table.Column<long>(type: "bigint", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StartUnix = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duration", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_DurationId",
                table: "Days",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DurationId",
                table: "Bookings",
                column: "DurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Duration_DurationId",
                table: "Bookings",
                column: "DurationId",
                principalTable: "Duration",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Duration_DurationId",
                table: "Days",
                column: "DurationId",
                principalTable: "Duration",
                principalColumn: "Id");
        }
    }
}
