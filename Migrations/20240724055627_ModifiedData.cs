using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillasWebProject.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "occupancy",
                table: "VillaDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sqft",
                table: "VillaDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "occupancy",
                table: "VillaDetails");

            migrationBuilder.DropColumn(
                name: "sqft",
                table: "VillaDetails");
        }
    }
}
