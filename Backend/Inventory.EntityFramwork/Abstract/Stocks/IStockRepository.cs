using Inventory.Core.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Abstract.Stocks
{
    public interface IStockRepository : IEntityBaseRepository<Stock> { }
}
