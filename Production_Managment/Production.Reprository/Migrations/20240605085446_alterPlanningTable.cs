using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Reprository.Migrations
{
    /// <inheritdoc />
    public partial class alterPlanningTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Planning",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Planning");
        }
    }
}
