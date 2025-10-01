using HR_Horizon.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace HR_Horizon_Dashboard.ViewModels
{
    public class AssignUserViewModel
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        public ICollection<Employee>? Employees { get; set; }
        public ICollection<ApplicationUser>? ApplicationUsers { get; set; }



    }
}
