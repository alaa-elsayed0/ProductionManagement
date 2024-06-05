using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Reprository.Migrations
{
    /// <inheritdoc />
    public partial class AlterProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdactName",
                table: "Tracking",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ProdactName",
                table: "StopRecords",
                newName: "ProductName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Tracking",
                newName: "ProdactName");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "StopRecords",
                newName: "ProdactName");
        }
    }
}
