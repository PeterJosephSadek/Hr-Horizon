using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Contexts;
using HR_Horizon.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Repositories
{

    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            var user = await _context.Users.OfType<ApplicationUser>().Include(u => u.Employee).FirstOrDefaultAsync(u => u.Id == id)
                ;
            return user;
        }

        public  IQueryable<ApplicationUser> GetUnassigndAccounts()
        {
           return  _context.Users.OfType<ApplicationUser>().Where(U => U.EmployeeId == null);
        }

        public async Task<int> UpdateAsync(ApplicationUser ApplicationUser)
        {
            _context.Users.Update(ApplicationUser);
            return await _context.SaveChangesAsync();
        }
    }
}
