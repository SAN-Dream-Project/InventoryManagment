using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_BharadaCreditDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_BharadaCreditDetail_BharadaSaleDetail_BharataSaleDetailID",
                        column: x => x.BharataSaleDetailID,
                        principalTable: "BharadaSaleDetail",
                        principalColumn: "BharadaSaleDetailID");
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BharadaCreditDetail");
        }
    }
}
