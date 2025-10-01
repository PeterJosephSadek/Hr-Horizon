using HR_Horizon.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HR_Horizon_Dashboard.ViewModels
{
    public class CreateEmployeeViewModelcs
    {
        [Required]
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Email Address is Required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string? ProfileImageURL { get; set; }
        [Required]
        public string Position { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public int EmploymentTypeId { get; set; }
        public int EmploymentStatusId { get; set; }
        public DateOnly? JoiningDate { get; set; }

        // Dropdown data
        public IEnumerable<SelectListItem>? Departments { get; set; }
        public IEnumerable<SelectListItem>? Managers { get; set; }
        public IEnumerable<SelectListItem>? EmploymentStatauses { get; set; }
        public IEnumerable<SelectListItem>? EmploymentTypes { get; set; }

    }

    public enum Gender
    {
        Male = 'M',
        Female = 'F'
    }
}
