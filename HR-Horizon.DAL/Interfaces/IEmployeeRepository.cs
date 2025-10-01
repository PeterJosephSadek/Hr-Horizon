using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAllAsync();
        IQueryable<Employee> SearchByNameAsync(string SearchWord);
        IQueryable<Employee> GetManagers();
        IQueryable<Employee> GetUnassignedEmployees();


        Task<Employee?> GetByIdAsync(int id);

        Task<int> AddAsync(Employee Employee);

        Task<int> UpdateAsync(Employee Employee);
        Task<int> DeleteAsync(int id);
    }
}
