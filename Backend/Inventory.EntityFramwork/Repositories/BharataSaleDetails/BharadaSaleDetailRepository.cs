using Inventory.Core.BharadaSaleDetails;
using Inventory.EntityFramwork.Abstract.BharadaSaleDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.BharataSaleDetails
{
    public class BharadaSaleDetailRepository : EntityBaseRepository<BharadaSaleDetail>, IBharadaSaleDetailRepository
    {
        public BharadaSaleDetailRepository(InventoryContext context)
            : base(context)
        { }
    }
}
