using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Reprository.Migrations
{
    /// <inheritdoc />
    public partial class AllowNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Planning_ProductPlanningId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Planning_Products_ProductId",
                table: "Planning");

            migrationBuilder.DropForeignKey(
                name: "FK_StopRecords_Planning_ProductPlanningId",
                table: "StopRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracking_Planning_ProductPlanningId",
                table: "Tracking");

            migrationBuilder.AlterColumn<int>(
                name: "ProductPlanningId",
                table: "Tracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductPlanningId",
                table: "StopRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Planning",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductPlanningId",
                table: "Operation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Planning_ProductPlanningId",
                table: "Operation",
                column: "ProductPlanningId",
                principalTable: "Planning",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planning_Products_ProductId",
                table: "Planning",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StopRecords_Planning_ProductPlanningId",
                table: "StopRecords",
                column: "ProductPlanningId",
                principalTable: "Planning",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracking_Planning_ProductPlanningId",
                table: "Tracking",
                column: "ProductPlanningId",
                principalTable: "Planning",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Planning_ProductPlanningId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Planning_Products_ProductId",
                table: "Planning");

            migrationBuilder.DropForeignKey(
                name: "FK_StopRecords_Planning_ProductPlanningId",
                table: "StopRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracking_Planning_ProductPlanningId",
                table: "Tracking");

            migrationBuilder.AlterColumn<int>(
                name: "ProductPlanningId",
                table: "Tracking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductPlanningId",
                table: "StopRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Planning",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductPlanningId",
                table: "Operation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_StopRecords_Planning_ProductPlanningId",
                table: "StopRecords",
                column: "ProductPlanningId",
                principalTable: "Planning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracking_Planning_ProductPlanningId",
                table: "Tracking",
                column: "ProductPlanningId",
                principalTable: "Planning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
