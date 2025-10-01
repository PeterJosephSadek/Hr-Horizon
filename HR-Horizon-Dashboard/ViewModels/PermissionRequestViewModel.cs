namespace HR_Horizon_Dashboard.ViewModels
{
    public class PermissionRequestViewModel
    {
        public DateOnly RequestedDate { get; set; }
        public string Comment { get; set; }
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set; }
    }
}
