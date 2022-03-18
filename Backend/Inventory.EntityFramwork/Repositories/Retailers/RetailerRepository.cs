using Inventory.Core.Retailers;
using Inventory.EntityFramwork.Abstract.Retailers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.Retailers
{
    public class RetailerRepository : EntityBaseRepository<Retailer>, IRetailerRepository
    {
        public RetailerRepository(InventoryContext context)
            : base(context)
        { }
    }
}
