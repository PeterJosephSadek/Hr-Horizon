using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Interfaces
{
    public interface IEmploymentStatusRepository
    {
        IQueryable<EmploymentStatus> GetAllAsync();

        Task<EmploymentStatus?> GetByIdAsync(int id);

        Task<int> AddAsync(EmploymentStatus employmentStatus);

        Task<int> UpdateAsync(EmploymentStatus employmentStatus);
        Task<int> DeleteAsync(int id);
    }
}
