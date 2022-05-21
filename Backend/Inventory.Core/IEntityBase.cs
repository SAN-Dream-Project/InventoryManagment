using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core
{
    public interface IEntityBase
    {
         Guid Id { get; set; }
         string? CreatedBy { get; set; }
         DateTime? CreatedDate { get; set; }
         string? ModifiedBy { get; set; }
         DateTime? ModifiedDate { get; set; }
         //string? DeletedBy { get; set; }
         //DateTime? DeleteDate { get; set; }
    }
}
