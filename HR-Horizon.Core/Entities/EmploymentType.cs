namespace HR_Horizon.Core.Entities
{
    public class EmploymentType : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Employee>? Employees { get; set; }
    }
}