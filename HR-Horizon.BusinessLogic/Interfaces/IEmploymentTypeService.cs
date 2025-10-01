using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.BusinessLogic.Interfaces
{
    public interface IEmploymentTypeService
    {
        Task<int> AddAsync(EmploymentTypeDto EmploymentTypeDto, string AddedBy);
        Task<int> SoftDeleteAsync(int id);
        Task<int> UpdateAsync(EmploymentTypeDto EmploymentTypeDto);
        Task<EmploymentType> GetByIdAsync(int id);
        Task<IEnumerable<EmploymentType>> GetAllAsync();
    }
}
