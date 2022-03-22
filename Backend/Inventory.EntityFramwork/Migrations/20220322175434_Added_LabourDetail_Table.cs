using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_LabourDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabourDetail",
                columns: table => new
                {
                    LabourDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    LabourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourDetail", x => x.LabourDetailID);
                    table.ForeignKey(
                        name: "FK_LabourDetail_Labour_LabourID",
                        column: x => x.LabourID,
                        principalTable: "Labour",
                        principalColumn: "LabourID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabourDetail_LabourID",
                table: "LabourDetail",
                column: "LabourID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabourDetail");
        }
    }
}
