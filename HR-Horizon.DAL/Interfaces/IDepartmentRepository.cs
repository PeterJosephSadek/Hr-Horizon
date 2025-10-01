using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> GetAllAsync();

        Task<Department?> GetByIdAsync(int id);

        Task<int> AddAsync(Department department);

        Task<int> UpdateAsync(Department department);
        Task<int> DeleteAsync(int id);
    }
}
