using Inventory.Core.Labours;
using Inventory.EntityFramwork.Abstract.Labours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.Labours
{
    public class LabourRepository : EntityBaseRepository<Labour>, ILabourRepository
    {
        public LabourRepository(InventoryContext context)
            : base(context)
        { }
    }
}
