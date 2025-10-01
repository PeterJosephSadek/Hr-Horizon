using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR_Horizon.BusinessLogic.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {

        private readonly IEmploymentTypeRepository _EmploymentTypeRepository;

        public EmploymentTypeService(IEmploymentTypeRepository EmploymentTypeRepository)
        {
            _EmploymentTypeRepository = EmploymentTypeRepository;
        }

        public async Task<int> AddAsync(EmploymentTypeDto Dto, string AddedBy)
        {
            EmploymentType EmploymentType = new EmploymentType()
            {
                Name = Dto.Name,
                AddedBy = AddedBy,
                AddedOn = DateTime.Now,
            };
            return await _EmploymentTypeRepository.AddAsync(EmploymentType);
        }

        public async Task<IEnumerable<EmploymentType>> GetAllAsync()
        {
            return await _EmploymentTypeRepository.GetAllAsync().ToListAsync();
        }

        public async Task<EmploymentType> GetByIdAsync(int id)
        {
            var EmploymentType = await _EmploymentTypeRepository.GetByIdAsync(id);

            if (EmploymentType != null)
            {
                return EmploymentType;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> SoftDeleteAsync(int id)
        {
            EmploymentType EmploymentType = await GetByIdAsync(id);
            if (EmploymentType != null)
            {
                EmploymentType.IsDeleted = true;
            }
            return await _EmploymentTypeRepository.UpdateAsync(EmploymentType);
        }

        public async Task<int> UpdateAsync(EmploymentTypeDto employmentTypeDto)
        {
            EmploymentType EmploymentType = await GetByIdAsync(employmentTypeDto.Id);
            if (employmentTypeDto != null)
            {
                employmentTypeDto.Name = employmentTypeDto.Name;
            }
            return await _EmploymentTypeRepository.UpdateAsync(EmploymentType);
        }
    }
}
