using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace HR_Horizon.BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> AddAsync(DepartmentDto Dto,string AddedBy)
        {
            Department department = new Department()
            {
                Name = Dto.Name,
                AddedBy = AddedBy,
                AddedOn = DateTime.Now,
            };
           return await _departmentRepository.AddAsync(department);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync().ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
           var department = await _departmentRepository.GetByIdAsync(id);

            if (department != null) {
                return department;
            }
            else {
                return null;
            }
        }

        public async Task<int> SoftDeleteAsync(int id)
        {
            Department department = await GetByIdAsync(id);
            if (department != null)
            {
                department.IsDeleted = true;
            }
            return await _departmentRepository.UpdateAsync(department);
        }

        public async Task<int> UpdateAsync(DepartmentDto departmentDto)
        {
            Department department = await GetByIdAsync(departmentDto.Id);
            if (department != null)
            {
                department.Name = departmentDto.Name;
            }
            return await _departmentRepository.UpdateAsync(department);
        }
    }
}
