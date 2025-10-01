using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        IQueryable<ApplicationUser> GetUnassigndAccounts();
        Task<int> UpdateAsync(ApplicationUser ApplicationUser);
    }
}
