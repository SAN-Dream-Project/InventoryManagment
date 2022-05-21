using Inventory.Core.LabourDetails;
using Inventory.Core.LabourRates;
using Inventory.EntityFramwork.Abstract.LabourDetails;
using Inventory.EntityFramwork.Abstract.LabourRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.LabourDetails
{
    public class LabourDetailRepository : EntityBaseRepository<LabourDetail>, ILabourDetailRepository
    {
        public LabourDetailRepository(InventoryContext context)
            : base(context)
        { }
    }
}
