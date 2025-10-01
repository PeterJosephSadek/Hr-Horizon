using System.ComponentModel.DataAnnotations;

namespace HR_Horizon_Dashboard.ViewModels
{
    public class CreateEmploymentTypeViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
