using Inventory.Core.LabourRates;
using Inventory.EntityFramwork.Abstract.LabourRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.LabourRates
{
    public class LabourRateRepository : EntityBaseRepository<LabourRate>, ILabourRateRepository
    {
        public LabourRateRepository(InventoryContext context)
            : base(context)
        { }
    }
}
