using Inventory.Core.GoodSuppliers;
using Inventory.EntityFramwork.Abstract.GoodSuppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.GoodSuppliers
{
    internal class GoodSupplierRepository : EntityBaseRepository<GoodSupplier>, IGoodSupplierRepository
    {
        public GoodSupplierRepository(InventoryContext context)
            : base(context)
        { }
    }
}
