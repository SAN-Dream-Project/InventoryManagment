using Inventory.Core.RateTables;
using Inventory.EntityFramwork.Abstract.BharadaRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.BharadaRates
{
    public class BharadaRateRepository : EntityBaseRepository<BharadaRate>, IBharadaRateRepository
    {
        public BharadaRateRepository(InventoryContext context)
            : base(context)
        { }
    }
}
