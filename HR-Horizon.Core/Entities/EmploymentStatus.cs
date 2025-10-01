namespace HR_Horizon.Core.Entities
{
    public class EmploymentStatus : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Employee>? Employees { get; set; }
    }
}