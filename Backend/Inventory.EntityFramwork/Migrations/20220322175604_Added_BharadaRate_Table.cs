using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_BharadaRate_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BharadaRate",
                columns: table => new
                {
                    BharadaRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateCriteriaID = table.Column<int>(type: "int", nullable: false),
                    RateCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BharadaRate", x => x.BharadaRateID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BharadaRate");
        }
    }
}
