using Inventory.Core.EmplyeeDetails;
using Inventory.EntityFramwork.Abstract.EmplyeeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityFramwork.Repositories.EmployeeDetails
{
    public class EmployeeDetailRepository : EntityBaseRepository<EmployeeDetail>, IEmployeeDetailRepository
    {
        public EmployeeDetailRepository(InventoryContext context)
            : base(context)
        { }
    }
}
