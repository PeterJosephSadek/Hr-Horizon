using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Interfaces
{
    public interface IEmploymentTypeRepository
    {
        IQueryable<EmploymentType> GetAllAsync();

        Task<EmploymentType?> GetByIdAsync(int id);

        Task<int> AddAsync(EmploymentType employmentType);

        Task<int> UpdateAsync(EmploymentType employmentType);
        Task<int> DeleteAsync(int id);
    }
}
