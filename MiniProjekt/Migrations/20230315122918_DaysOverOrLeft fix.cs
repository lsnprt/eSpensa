using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjekt.Migrations
{
    /// <inheritdoc />
    public partial class DaysOverOrLeftfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysOverOrLeft",
                table: "FoodItems",
                type: "Int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysOverOrLeft",
                table: "FoodItems");
        }
    }
}
