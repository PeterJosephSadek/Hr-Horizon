using System.ComponentModel.DataAnnotations;

namespace HR_Horizon_Dashboard.ViewModels
{
    public class CreateDepartmentViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
