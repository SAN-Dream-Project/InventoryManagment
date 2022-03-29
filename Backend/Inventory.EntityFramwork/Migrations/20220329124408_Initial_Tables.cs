using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.EntityFramwork.Migrations
{
    public partial class Initial_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BharadaRate",
                columns: table => new
                {
                    BharadaRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateCriteriaID = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "EmployeeDetail",
                columns: table => new
                {
                    EmployeeDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmplyeeType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetail", x => x.EmployeeDetailID);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodID);
                });

            migrationBuilder.CreateTable(
                name: "GoodSuppliers",
                columns: table => new
                {
                    GoodSupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodSuppliers", x => x.GoodSupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Kadatas",
                columns: table => new
                {
                    KadataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KadtaQuantity = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kadatas", x => x.KadataID);
                });

            migrationBuilder.CreateTable(
                name: "Labour",
                columns: table => new
                {
                    LabourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labour", x => x.LabourID);
                });

            migrationBuilder.CreateTable(
                name: "LabourRate",
                columns: table => new
                {
                    LabourRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourRate", x => x.LabourRateID);
                });

            migrationBuilder.CreateTable(
                name: "Retailer",
                columns: table => new
                {
                    RetailerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailer", x => x.RetailerID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryMobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryMobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDetail",
                columns: table => new
                {
                    SalaryDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonthlySalary = table.Column<double>(type: "float", nullable: true),
                    EmplyeeType = table.Column<int>(type: "int", nullable: true),
                    EmployeeDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    WorkingDays = table.Column<double>(type: "float", nullable: true),
                    PaidAmount = table.Column<double>(type: "float", nullable: true),
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
                        principalColumn: "EmployeeDetailID");
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stock_Goods_GoodID",
                        column: x => x.GoodID,
                        principalTable: "Goods",
                        principalColumn: "GoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabourDetail",
                columns: table => new
                {
                    LabourDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: true),
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
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
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
                        principalColumn: "LabourRateID");
                });

            migrationBuilder.CreateTable(
                name: "BharadaSaleDetail",
                columns: table => new
                {
                    BharadaSaleDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BharadaRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    RetailerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    LabourRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalLabourCosting = table.Column<double>(type: "float", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RetailerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quntity = table.Column<double>(type: "float", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    LabourRateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalLabourCosting = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
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
                        principalColumn: "LabourRateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Retailer_RetailerID",
                        column: x => x.RetailerID,
                        principalTable: "Retailer",
                        principalColumn: "RetailerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BharadaCreditDetail",
                columns: table => new
                {
                    BharadaCreditDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RetailerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BharadaSaleDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaidAmount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BharadaCreditDetail", x => x.BharadaCreditDetailID);
                    table.ForeignKey(
                        name: "FK_BharadaCreditDetail_BharadaSaleDetail_BharadaSaleDetailID",
                        column: x => x.BharadaSaleDetailID,
                        principalTable: "BharadaSaleDetail",
                        principalColumn: "BharadaSaleDetailID");
                    table.ForeignKey(
                        name: "FK_BharadaCreditDetail_Retailer_RetailerID",
                        column: x => x.RetailerID,
                        principalTable: "Retailer",
                        principalColumn: "RetailerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BharadaCreditDetail_BharadaSaleDetailID",
                table: "BharadaCreditDetail",
                column: "BharadaSaleDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_BharadaCreditDetail_RetailerID",
                table: "BharadaCreditDetail",
                column: "RetailerID");

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

            migrationBuilder.CreateIndex(
                name: "IX_LabourDetail_LabourID",
                table: "LabourDetail",
                column: "LabourID");

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

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetail_EmployeeDetailID",
                table: "SalaryDetail",
                column: "EmployeeDetailID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Stock_GoodID",
                table: "Stock",
                column: "GoodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BharadaCreditDetail");

            migrationBuilder.DropTable(
                name: "LabourDetail");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SalaryDetail");

            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BharadaSaleDetail");

            migrationBuilder.DropTable(
                name: "Labour");

            migrationBuilder.DropTable(
                name: "GoodSuppliers");

            migrationBuilder.DropTable(
                name: "Kadatas");

            migrationBuilder.DropTable(
                name: "EmployeeDetail");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "BharadaRate");

            migrationBuilder.DropTable(
                name: "LabourRate");

            migrationBuilder.DropTable(
                name: "Retailer");
        }
    }
}
