using Inventory.Core.SalaryDetails;
using Inventory.EntityFramwork.Abstract.SalaryDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.SalaryDetails
{
    public class SalaryDetailRepository : EntityBaseRepository<SalaryDetail>, ISalaryDetailRepository
    {
        public SalaryDetailRepository(InventoryContext context)
            : base(context)
        { }
    }
}
