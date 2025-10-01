using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Contexts;
using HR_Horizon.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> AddAsync(Employee Employee)
        {
                   await _applicationDbContext.AddAsync(Employee);
            return await _applicationDbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(int id)
        {
            _applicationDbContext.Remove(id);
            return await _applicationDbContext.SaveChangesAsync();
        }

        public  IQueryable<Employee> GetAllAsync()
        {
            return  _applicationDbContext.Employees.OrderBy(e=>e.FullName);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
             return await _applicationDbContext.Employees.FindAsync(id);
        }

        public IQueryable<Employee> GetManagers()
        {
           return _applicationDbContext.Employees.Where(e => e.ManagerId == null).OrderBy(e=>e.FullName);
        }

        public IQueryable<Employee> GetUnassignedEmployees()
        {
            // Get all employee IDs that are already assigned to any account
            var assignedEmployeeIds = _applicationDbContext.Users.OfType<ApplicationUser>()
                .Where(u => u.EmployeeId != null)
                .Select(u => u.EmployeeId.Value)  // Get the EmployeeId, not the User Id
                .ToList();

            // Return employees that are NOT in the assignedEmployeeIds list
            var unassignedEmployees = _applicationDbContext.Employees
                .Where(e => !assignedEmployeeIds.Contains(e.Id));  // Compare integer to integer

            return unassignedEmployees;
        }

        public IQueryable<Employee> SearchByNameAsync(string SearchWord)
        {
            return _applicationDbContext.Employees
                .Where(e => e.FullName.Contains(SearchWord)).OrderBy(e=>e.FullName);
        }

        public async Task<int> UpdateAsync(Employee Employee)
        {
              _applicationDbContext.Update(Employee);
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
