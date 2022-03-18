using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_Purchase_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodSupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrossGoodQuantity = table.Column<double>(type: "float", nullable: true),
                    GoodRate = table.Column<double>(type: "float", nullable: true),
                    KadataID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KadtaTotal = table.Column<int>(type: "int", nullable: true),
                    NetGoodQuantity = table.Column<double>(type: "float", nullable: true),
                    LabourRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalLabourCosting = table.Column<double>(type: "float", nullable: true),
                    TotalAmout = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchase_Goods_GoodID",
                        column: x => x.GoodID,
                        principalTable: "Goods",
                        principalColumn: "GoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_GoodSuppliers_GoodSupplierID",
                        column: x => x.GoodSupplierID,
                        principalTable: "GoodSuppliers",
                        principalColumn: "GoodSupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Kadatas_KadataID",
                        column: x => x.KadataID,
                        principalTable: "Kadatas",
                        principalColumn: "KadataID");
                    table.ForeignKey(
                        name: "FK_Purchase_LabourRate_LabourRateID",
                        column: x => x.LabourRateID,
                        principalTable: "LabourRate",
                        principalColumn: "LabourRateId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_GoodID",
                table: "Purchase",
                column: "GoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_GoodSupplierID",
                table: "Purchase",
                column: "GoodSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_KadataID",
                table: "Purchase",
                column: "KadataID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_LabourRateID",
                table: "Purchase",
                column: "LabourRateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
