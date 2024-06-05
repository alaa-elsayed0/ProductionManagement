using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Reprository.Migrations
{
    /// <inheritdoc />
    public partial class AddProdactNameToRecordsAndTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProdactName",
                table: "Tracking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProdactName",
                table: "StopRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductStopRecords",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    StopRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStopRecords", x => new { x.ProductsId, x.StopRecordsId });
                    table.ForeignKey(
                        name: "FK_ProductStopRecords_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStopRecords_StopRecords_StopRecordsId",
                        column: x => x.StopRecordsId,
                        principalTable: "StopRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTracking",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    TrackingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTracking", x => new { x.ProductsId, x.TrackingsId });
                    table.ForeignKey(
                        name: "FK_ProductTracking_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTracking_Tracking_TrackingsId",
                        column: x => x.TrackingsId,
                        principalTable: "Tracking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStopRecords_StopRecordsId",
                table: "ProductStopRecords",
                column: "StopRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTracking_TrackingsId",
                table: "ProductTracking",
                column: "TrackingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStopRecords");

            migrationBuilder.DropTable(
                name: "ProductTracking");

            migrationBuilder.DropColumn(
                name: "ProdactName",
                table: "Tracking");

            migrationBuilder.DropColumn(
                name: "ProdactName",
                table: "StopRecords");
        }
    }
}
