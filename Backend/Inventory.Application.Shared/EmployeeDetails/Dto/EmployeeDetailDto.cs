using Inventory.Core.Shared.EmplyeeTypes;
using Inventory.Core.Shared.UserAndRoles.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Shared.EmployeeDetails.Dto
{
    public class EmployeeDetailDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? Address { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public EmplyeeType EmplyeeType { get; set; }
    }
}
