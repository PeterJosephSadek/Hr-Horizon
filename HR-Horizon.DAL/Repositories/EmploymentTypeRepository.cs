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
    public class EmploymentTypeRepository : IEmploymentTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmploymentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(EmploymentType EmploymentType)
        {
            await _context.EmploymentTypes.AddAsync(EmploymentType);

            int respond = await _context.SaveChangesAsync();

            return EmploymentType.Id;

        }

        public async Task<int> DeleteAsync(int id)
        {
            EmploymentType? EmploymentType = await GetByIdAsync(id);
            if (EmploymentType != null)
                _context.EmploymentTypes.Remove(EmploymentType);

            return await _context.SaveChangesAsync();
        }

        public IQueryable<EmploymentType> GetAllAsync()
        {
            return _context.EmploymentTypes;
        }

        public async Task<EmploymentType?> GetByIdAsync(int id)
        {
            return await _context.EmploymentTypes
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> UpdateAsync(EmploymentType EmploymentType)
        {
            _context.EmploymentTypes.Update(EmploymentType);
            return await _context.SaveChangesAsync();
        }
    }
}
