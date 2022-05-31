using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlingsKlipp.Migrations
{
    public partial class ChangedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TimeBlocks",
                newName: "Day");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Day",
                table: "TimeBlocks",
                newName: "Date");
        }
    }
}
