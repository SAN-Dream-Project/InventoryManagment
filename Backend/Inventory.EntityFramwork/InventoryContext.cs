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
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        
      }
   }
}