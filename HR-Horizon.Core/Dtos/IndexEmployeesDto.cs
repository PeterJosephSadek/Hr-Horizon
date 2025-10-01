using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.Core.Dtos
{
    public class IndexEmployeesDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly Joined { get; set; }
        public string Type { get; set; } = null!;
        public string ProfileImageURL { get; set; }=null!;

        public bool IsActive { get; set; }

        public string DepartmentName { get; set; } = null!; 

        public int? DepartmentId { get; set; }

        public int? ManagerId { get; set; }
        public string ManagerName { get; set; } = null!;




    }
}
