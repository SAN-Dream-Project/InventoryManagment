using Inventory.Core.SaleDetails;
using Inventory.EntityFramwork.Abstract;
using Inventory.EntityFramwork.Abstract.SaleDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.SaleDetails
{
    public class SaleDetailRepository : EntityBaseRepository<SaleDetail>, ISaleDetailRepository
    {
        public SaleDetailRepository(InventoryContext context)
            : base(context)
        { }
    }
}
