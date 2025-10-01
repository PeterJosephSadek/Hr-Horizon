using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Contexts;
using HR_Horizon.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);

            int respond = await _context.SaveChangesAsync();

            return department.Id;

        }

        public async Task<int> DeleteAsync(int id)
        {
            Department? department = await GetByIdAsync(id);
            if (department != null)
                _context.Departments.Remove(department);
            
            return await _context.SaveChangesAsync();
        }

        public IQueryable<Department> GetAllAsync()
        {
            return _context.Departments;
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            return await _context.SaveChangesAsync();
        }
    }
}
