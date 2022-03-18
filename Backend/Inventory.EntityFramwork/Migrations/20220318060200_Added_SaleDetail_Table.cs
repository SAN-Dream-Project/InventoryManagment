using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_SaleDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RetailerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quntity = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    LabourRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalLabourCosting = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.SaleDetailID);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Goods_GoodID",
                        column: x => x.GoodID,
                        principalTable: "Goods",
                        principalColumn: "GoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_LabourRate_LabourRateID",
                        column: x => x.LabourRateID,
                        principalTable: "LabourRate",
                        principalColumn: "LabourRateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Retailer_RetailerID",
                        column: x => x.RetailerID,
                        principalTable: "Retailer",
                        principalColumn: "RetailerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_GoodID",
                table: "SaleDetail",
                column: "GoodID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_LabourRateID",
                table: "SaleDetail",
                column: "LabourRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_RetailerID",
                table: "SaleDetail",
                column: "RetailerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleDetail");
        }
    }
}
