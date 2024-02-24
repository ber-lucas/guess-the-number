using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace guess_the_number.Migrations
{
    /// <inheritdoc />
    public partial class featCriandonovoscamposnatabelaPlayereGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TargetNumber",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TargetNumber",
                table: "Games");
        }
    }
}
