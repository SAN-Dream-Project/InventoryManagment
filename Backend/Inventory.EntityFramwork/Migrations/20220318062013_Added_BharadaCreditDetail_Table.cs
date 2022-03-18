using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_BharadaCreditDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BharataSaleDetail_BharadaRate_BharadaRateID",
                table: "BharataSaleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BharataSaleDetail_Retailer_RetailerID",
                table: "BharataSaleDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "RetailerID",
                table: "BharataSaleDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BharadaRateID",
                table: "BharataSaleDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "BharadaCreditDetail",
                columns: table => new
                {
                    BharadaCreditDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RetailerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BharataSaleDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaidAmout = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BharadaCreditDetail", x => x.BharadaCreditDetailID);
                    table.ForeignKey(
                        name: "FK_BharadaCreditDetail_BharataSaleDetail_BharataSaleDetailID",
                        column: x => x.BharataSaleDetailID,
                        principalTable: "BharataSaleDetail",
                        principalColumn: "BharataSaleDetailID");
                    table.ForeignKey(
                        name: "FK_BharadaCreditDetail_Retailer_RetailerID",
                        column: x => x.RetailerID,
                        principalTable: "Retailer",
                        principalColumn: "RetailerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BharadaCreditDetail_BharataSaleDetailID",
                table: "BharadaCreditDetail",
                column: "BharataSaleDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_BharadaCreditDetail_RetailerID",
                table: "BharadaCreditDetail",
                column: "RetailerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BharataSaleDetail_BharadaRate_BharadaRateID",
                table: "BharataSaleDetail",
                column: "BharadaRateID",
                principalTable: "BharadaRate",
                principalColumn: "BharadaRateID");

            migrationBuilder.AddForeignKey(
                name: "FK_BharataSaleDetail_Retailer_RetailerID",
                table: "BharataSaleDetail",
                column: "RetailerID",
                principalTable: "Retailer",
                principalColumn: "RetailerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BharataSaleDetail_BharadaRate_BharadaRateID",
                table: "BharataSaleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BharataSaleDetail_Retailer_RetailerID",
                table: "BharataSaleDetail");

            migrationBuilder.DropTable(
                name: "BharadaCreditDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "RetailerID",
                table: "BharataSaleDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BharadaRateID",
                table: "BharataSaleDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BharataSaleDetail_BharadaRate_BharadaRateID",
                table: "BharataSaleDetail",
                column: "BharadaRateID",
                principalTable: "BharadaRate",
                principalColumn: "BharadaRateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BharataSaleDetail_Retailer_RetailerID",
                table: "BharataSaleDetail",
                column: "RetailerID",
                principalTable: "Retailer",
                principalColumn: "RetailerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
