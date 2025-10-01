using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.Core.Dtos
{
    public class PermissionRequestDto
    {
        public int EmployeeId { get; set; }
        public DateOnly RequestedDate { get; set; }
        public string Comment { get; set; }
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set; }
    }
}
