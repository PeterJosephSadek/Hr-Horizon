using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Interfaces
{
    public interface IPermissionRepository
    {
        IQueryable<PermissionRequest> GetAllAsync();

        Task<PermissionRequest?> GetByIdAsync(int id);

        Task<int> AddAsync(PermissionRequest Request);

        Task<int> UpdateAsync(PermissionRequest Request);
        Task<int> DeleteAsync(int id);
    }
}
