using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_BharadaSaleDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LabourRateId",
                table: "LabourRate",
                newName: "LabourRateID");

            migrationBuilder.RenameColumn(
                name: "LabourId",
                table: "Labour",
                newName: "LabourID");

            migrationBuilder.CreateTable(
                name: "BharadaSaleDetail",
                columns: table => new
                {
                    BharadaSaleDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BharadaRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quntity = table.Column<double>(type: "float", nullable: true),
                    RetailerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToatalAmount = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    LabourRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalLabourCosting = table.Column<double>(type: "float", nullable: false),
                    NetAmount = table.Column<double>(type: "float", nullable: true),
                    PaidAmount = table.Column<double>(type: "float", nullable: true),
                    RemainingAmount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BharadaSaleDetail", x => x.BharadaSaleDetailID);
                    table.ForeignKey(
                        name: "FK_BharadaSaleDetail_BharadaRate_BharadaRateID",
                        column: x => x.BharadaRateID,
                        principalTable: "BharadaRate",
                        principalColumn: "BharadaRateID");
                    table.ForeignKey(
                        name: "FK_BharadaSaleDetail_LabourRate_LabourRateID",
                        column: x => x.LabourRateID,
                        principalTable: "LabourRate",
                        principalColumn: "LabourRateID");
                    table.ForeignKey(
                        name: "FK_BharadaSaleDetail_Retailer_RetailerID",
                        column: x => x.RetailerID,
                        principalTable: "Retailer",
                        principalColumn: "RetailerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BharadaSaleDetail_BharadaRateID",
                table: "BharadaSaleDetail",
                column: "BharadaRateID");

            migrationBuilder.CreateIndex(
                name: "IX_BharadaSaleDetail_LabourRateID",
                table: "BharadaSaleDetail",
                column: "LabourRateID");

            migrationBuilder.CreateIndex(
                name: "IX_BharadaSaleDetail_RetailerID",
                table: "BharadaSaleDetail",
                column: "RetailerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BharadaSaleDetail");

            migrationBuilder.RenameColumn(
                name: "LabourRateID",
                table: "LabourRate",
                newName: "LabourRateId");

            migrationBuilder.RenameColumn(
                name: "LabourID",
                table: "Labour",
                newName: "LabourId");
        }
    }
}
