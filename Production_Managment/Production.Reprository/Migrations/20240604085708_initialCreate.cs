using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Reprository.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approval = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPlanningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approval = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductionOperationId = table.Column<int>(type: "int", nullable: true),
                    StopRecordsId = table.Column<int>(type: "int", nullable: true),
                    TrackingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planning_Operation_ProductionOperationId",
                        column: x => x.ProductionOperationId,
                        principalTable: "Operation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPlanningId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Planning_ProductPlanningId",
                        column: x => x.ProductPlanningId,
                        principalTable: "Planning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StopRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopReasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DownTimeDuration = table.Column<int>(type: "int", nullable: false),
                    AffectedOperations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPlanningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StopRecords_Planning_ProductPlanningId",
                        column: x => x.ProductPlanningId,
                        principalTable: "Planning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityProduced = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPlanningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracking_Planning_ProductPlanningId",
                        column: x => x.ProductPlanningId,
                        principalTable: "Planning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_ProductPlanningId",
                table: "Operation",
                column: "ProductPlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_ProductId",
                table: "Planning",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_ProductionOperationId",
                table: "Planning",
                column: "ProductionOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_StopRecordsId",
                table: "Planning",
                column: "StopRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_Planning_TrackingId",
                table: "Planning",
                column: "TrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductPlanningId",
                table: "Products",
                column: "ProductPlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_StopRecords_ProductPlanningId",
                table: "StopRecords",
                column: "ProductPlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_ProductPlanningId",
                table: "Tracking",
                column: "ProductPlanningId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Planning_ProductPlanningId",
                table: "Operation",
                column: "ProductPlanningId",
                principalTable: "Planning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planning_Products_ProductId",
                table: "Planning",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planning_StopRecords_StopRecordsId",
                table: "Planning",
                column: "StopRecordsId",
                principalTable: "StopRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planning_Tracking_TrackingId",
                table: "Planning",
                column: "TrackingId",
                principalTable: "Tracking",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Planning_ProductPlanningId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Planning_ProductPlanningId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StopRecords_Planning_ProductPlanningId",
                table: "StopRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracking_Planning_ProductPlanningId",
                table: "Tracking");

            migrationBuilder.DropTable(
                name: "Planning");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StopRecords");

            migrationBuilder.DropTable(
                name: "Tracking");
        }
    }
}
