using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Dtos;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> AddAsync(CreateEmployeeDto CreateEmployeeDto, string AddedBy)
        {
            Employee employee = new Employee()
            {
                Address = CreateEmployeeDto.Address,
                DepartmentId = CreateEmployeeDto.DepartmentId,
                EmploymentStatusId = CreateEmployeeDto.EmploymentStatusId,
                EmploymentTypeId = CreateEmployeeDto.EmploymentTypeId,
                FullName = CreateEmployeeDto.FullName,
                Gender = CreateEmployeeDto.Gender,
                ManagerId = CreateEmployeeDto.ManagerId,
                PhoneNumber = CreateEmployeeDto.PhoneNumber,
                ProfileImageURL = CreateEmployeeDto.ProfileImageURL,
                Position = CreateEmployeeDto.Position,
                JoiningDate = CreateEmployeeDto.JoiningDate,
                Email = CreateEmployeeDto.Email,

                AddedOn = DateTime.Now,
                IsActive = false,
                AddedBy = AddedBy,
            };
            try
            {
                return await _employeeRepository.AddAsync(employee);
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync().ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var emp = await _employeeRepository.GetByIdAsync(id);
            if (emp != null)
            {
                return emp;
            }
            else
                return null!;
        }

        public async Task<IEnumerable<Employee>> GetManagers()
        {
            return await _employeeRepository.GetManagers().ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetUnassignedEmployees()
        {
            return await _employeeRepository.GetUnassignedEmployees().ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchByNameAsync(string SearchWord)
        {
            return await _employeeRepository.SearchByNameAsync(SearchWord).ToListAsync();
        }

        public Task<int> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(CreateEmployeeDto CreateEmployeeDto)
        {
            throw new NotImplementedException();
        }

    }
}
