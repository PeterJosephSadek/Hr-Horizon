using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public char Gender { get; set; }
        public string? ProfileImageURL { get; set; }
        public string Position { get; set; } = null!;
        public int DepartmentId { get; set; }   
        public int? ManagerId { get; set; }
        public int EmploymentTypeId { get; set; }
        public int EmploymentStatusId { get; set; }
        public DateOnly? JoiningDate { get; set; }
        public bool IsActive { get; set; }

        public Department? Department { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public Employee? Manager { get; set; }

    }


}
