using Inventory.Core.BharadaCreditDetails;
using Inventory.EntityFramwork.Abstract.BharadaCreditDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.BharadaCreditDetails
{
    public class BharadaCreditDetailRepository : EntityBaseRepository<BharadaCreditDetail>, IBharadaCreditDetailRepository
    {
        public BharadaCreditDetailRepository(InventoryContext context)
            : base(context)
        { }
    }
}
