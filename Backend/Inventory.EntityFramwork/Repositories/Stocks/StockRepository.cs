using Inventory.Core.Stocks;
using Inventory.EntityFramwork.Abstract.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.Stocks
{
    public class StockRepository : EntityBaseRepository<Stock>, IStockRepository
    {
        public StockRepository(InventoryContext context)
            : base(context)
        { }
    }
}
