using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class ModifiedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationUnix",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "EndUnix",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "StartUnix",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "EndUnix",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StartUnix",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DurationUnix",
                table: "Treatments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EndUnix",
                table: "Days",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StartUnix",
                table: "Days",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EndUnix",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StartUnix",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
