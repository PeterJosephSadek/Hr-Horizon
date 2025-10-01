using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUser> GetAccountById(string id);
        Task<IEnumerable<ApplicationUser>> GetUnassigndAccounts();
        Task<int> AssignEmployeeToUser(int EmployeeId, string Username);

    }
}
