using Inventory.Core.Goods;
using Inventory.EntityFramwork.Abstract.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.Goods
{
    public class GoodRepository : EntityBaseRepository<Good>, IGoodRepository
    {
        public GoodRepository(InventoryContext context)
            : base(context)
        { }
    }
}
