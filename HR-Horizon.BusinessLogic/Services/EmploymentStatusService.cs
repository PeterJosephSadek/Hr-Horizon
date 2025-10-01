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
    public class EmploymentStatusService : IEmploymentStatusService
    {
        private readonly IEmploymentStatusRepository _EmploymentStatusRepository;

        public EmploymentStatusService(IEmploymentStatusRepository EmploymentStatusRepository)
        {
            _EmploymentStatusRepository = EmploymentStatusRepository;
        }

        public async Task<int> AddAsync(EmploymentStatusDto Dto, string AddedBy)
        {
            EmploymentStatus EmploymentStatus = new EmploymentStatus()
            {
                Name = Dto.Name,
                AddedBy = AddedBy,
                AddedOn = DateTime.Now,
            };
            return await _EmploymentStatusRepository.AddAsync(EmploymentStatus);
        }

        public async Task<IEnumerable<EmploymentStatus>> GetAllAsync()
        {
            return await _EmploymentStatusRepository.GetAllAsync().ToListAsync();
        }

        public async Task<EmploymentStatus> GetByIdAsync(int id)
        {
            var EmploymentStatus = await _EmploymentStatusRepository.GetByIdAsync(id);

            if (EmploymentStatus != null)
            {
                return EmploymentStatus;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> SoftDeleteAsync(int id)
        {
            EmploymentStatus EmploymentStatus = await GetByIdAsync(id);
            if (EmploymentStatus != null)
            {
                EmploymentStatus.IsDeleted = true;
            }
            return await _EmploymentStatusRepository.UpdateAsync(EmploymentStatus);
        }

        public async Task<int> UpdateAsync(EmploymentStatusDto employmentStatusDto)
        {
            EmploymentStatus EmploymentStatus = await GetByIdAsync(employmentStatusDto.Id);
            if (employmentStatusDto != null)
            {
                employmentStatusDto.Name = employmentStatusDto.Name;
            }
            return await _EmploymentStatusRepository.UpdateAsync(EmploymentStatus);
        }
    }
}
