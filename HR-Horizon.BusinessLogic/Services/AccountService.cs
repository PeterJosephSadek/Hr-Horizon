using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> AssignEmployeeToUser(int EmployeeId, string UserId)
        {
           var ApplicationUser = await _accountRepository.GetByIdAsync(UserId);
            if (ApplicationUser != null) 
            {
                ApplicationUser.EmployeeId = EmployeeId;
            }else
            { 
                throw new Exception();
            }
          return await _accountRepository.UpdateAsync(ApplicationUser);
        }

        public async Task<ApplicationUser> GetAccountById(string id)
        {
           return await _accountRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUnassigndAccounts()
        {
            return await _accountRepository.GetUnassigndAccounts().ToListAsync();
        }
    }
}
