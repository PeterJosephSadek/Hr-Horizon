using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.BusinessLogic.Interfaces
{
    public interface IPermissionService
    {
        Task<int> AddAsync(PermissionRequestDto requestDto, string AddedBy);
        Task<int> SoftDeleteAsync(int id);
        Task<int> UpdateAsync(PermissionRequestDto requestDto);
        Task<PermissionRequest> GetByIdAsync(int id);
        Task<IEnumerable<PermissionRequest>> GetAllAsync();
    }
}
