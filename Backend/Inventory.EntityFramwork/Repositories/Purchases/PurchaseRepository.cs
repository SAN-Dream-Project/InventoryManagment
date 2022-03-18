using Inventory.Core.Purchases;
using Inventory.EntityFramwork.Abstract.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.Purchases
{
    public class PurchaseRepository : EntityBaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(InventoryContext context)
            : base(context)
        { }
    }
}
