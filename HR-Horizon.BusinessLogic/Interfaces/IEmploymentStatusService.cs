using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.BusinessLogic.Interfaces
{
    public interface IEmploymentStatusService
    {
        Task<int> AddAsync(EmploymentStatusDto EmploymentStatusDto, string AddedBy);
        Task<int> SoftDeleteAsync(int id);
        Task<int> UpdateAsync(EmploymentStatusDto EmploymentStatusDto);
        Task<EmploymentStatus> GetByIdAsync(int id);
        Task<IEnumerable<EmploymentStatus>> GetAllAsync();
    }
}
