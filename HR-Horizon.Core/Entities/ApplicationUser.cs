using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
