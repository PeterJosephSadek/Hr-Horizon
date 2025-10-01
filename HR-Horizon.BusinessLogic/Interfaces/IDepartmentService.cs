using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.BusinessLogic.Interfaces
{
    public interface IDepartmentService
    {
        Task<int> AddAsync(DepartmentDto department,string AddedBy);
        Task<int> SoftDeleteAsync(int id);
        Task<int> UpdateAsync(DepartmentDto department);
        Task<Department> GetByIdAsync(int id);
        Task<IEnumerable<Department>> GetAllAsync();
    }
}
