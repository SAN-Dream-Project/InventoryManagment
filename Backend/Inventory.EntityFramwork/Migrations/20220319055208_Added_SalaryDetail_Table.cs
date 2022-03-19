using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Added_SalaryDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryDetail",
                columns: table => new
                {
                    SalaryDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonthlySalary = table.Column<double>(type: "float", nullable: true),
                    EmplyeeType = table.Column<int>(type: "int", nullable: true),
                    EmployeeDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WorkingDays = table.Column<double>(type: "float", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDetail", x => x.SalaryDetailID);
                    table.ForeignKey(
                        name: "FK_SalaryDetail_EmployeeDetail_EmployeeDetailID",
                        column: x => x.EmployeeDetailID,
                        principalTable: "EmployeeDetail",
                        principalColumn: "EmployeeDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetail_EmployeeDetailID",
                table: "SalaryDetail",
                column: "EmployeeDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryDetail");
        }
    }
}
