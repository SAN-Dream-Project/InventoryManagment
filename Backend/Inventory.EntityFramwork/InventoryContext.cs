using Inventory.Core.BharadaCreditDetails;
using Inventory.Core.BharataSaleDetails;
using Inventory.Core.EmplyeeDetails;
using Inventory.Core.Goods;
using Inventory.Core.GoodSuppliers;
using Inventory.Core.Kadatas;
using Inventory.Core.LabourDetails;
using Inventory.Core.LabourRates;
using Inventory.Core.Labours;
using Inventory.Core.Purchases;
using Inventory.Core.RateTables;
using Inventory.Core.Retailers;
using Inventory.Core.SalaryDetails;
using Inventory.Core.SaleDetails;
using Inventory.Core.Stocks;
using Inventory.Core.UserAndRoles.Users;
using Inventory.Core.Users.Roles;
using Microsoft.EntityFrameworkCore;

namespace Inventory.EntityFramwork
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Kadata> Kadatas { get; set; }
        public DbSet<GoodSupplier> GoodSuppliers { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<LabourRate> LabourRates { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<LabourDetail> LabourDetails { get; set; }
        public DbSet<Stock> Stokes { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<BharadaRate> BharadaRates { get; set; }
        public DbSet<BharataSaleDetail> BharataSaleDetails { get; set; }
        public DbSet<BharadaCreditDetail> BharadaCreditDetails { get; set; }
        public DbSet<EmployeeDetail> EmplyeeDetails { get; set; }
        public DbSet<SalaryDetail> SalaryDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}