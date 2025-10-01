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
    public class EmploymentStatusRepository : IEmploymentStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public EmploymentStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(EmploymentStatus EmploymentStatus)
        {
            await _context.EmploymentStatuses.AddAsync(EmploymentStatus);

            int respond = await _context.SaveChangesAsync();

            return EmploymentStatus.Id;

        }

        public async Task<int> DeleteAsync(int id)
        {
            EmploymentStatus? EmploymentStatus = await GetByIdAsync(id);
            if (EmploymentStatus != null)
                _context.EmploymentStatuses.Remove(EmploymentStatus);

            return await _context.SaveChangesAsync();
        }

        public IQueryable<EmploymentStatus> GetAllAsync()
        {
            return _context.EmploymentStatuses;
        }

        public async Task<EmploymentStatus?> GetByIdAsync(int id)
        {
            return await _context.EmploymentStatuses
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> UpdateAsync(EmploymentStatus EmploymentStatus)
        {
            _context.EmploymentStatuses.Update(EmploymentStatus);
            return await _context.SaveChangesAsync();
        }
    }
}
