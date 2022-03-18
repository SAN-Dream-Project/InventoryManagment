using Inventory.Core.Kadatas;
using Inventory.EntityFramwork.Abstract.Kadatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.Kadatas
{
    public class KadataRepository : EntityBaseRepository<Kadata>, IKadataRepository
    {
        public KadataRepository(InventoryContext context)
            : base(context)
        { }
    }
}
