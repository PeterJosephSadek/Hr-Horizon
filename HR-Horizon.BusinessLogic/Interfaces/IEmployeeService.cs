using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> AddAsync(CreateEmployeeDto CreateEmployeeDto, string AddedBy);
        Task<int> SoftDeleteAsync(int id);
        Task<int> UpdateAsync(CreateEmployeeDto CreateEmployeeDto);
        Task<Employee> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> SearchByNameAsync(string SearchWord);
        Task<IEnumerable<Employee>> GetManagers();
        Task<IEnumerable<Employee>> GetUnassignedEmployees();


    }
}
