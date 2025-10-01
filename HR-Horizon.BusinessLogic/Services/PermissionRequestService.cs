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
    public class PermissionRequestService : IPermissionService
    {
        private readonly IPermissionRepository _PermissionRepository;

        public PermissionRequestService(IPermissionRepository PermissionRepository)
        {
            _PermissionRepository = PermissionRepository;
        }

        public async Task<int> AddAsync(PermissionRequestDto requestDto, string AddedBy)
        {
            PermissionRequest request = new PermissionRequest()
            {
                AddedBy = AddedBy,
                AddedOn = DateTime.Now,
                Comment = requestDto.Comment,
                EmployeeId = requestDto.EmployeeId,
                TimeFrom = requestDto.TimeFrom,
                TimeTo = requestDto.TimeTo,
                RequestedDate = requestDto.RequestedDate,
            };

            return await _PermissionRepository.AddAsync(request);

        }

        public async Task<IEnumerable<PermissionRequest>> GetAllAsync()
        {
          return await  _PermissionRepository.GetAllAsync().ToListAsync();
        }

        public Task<PermissionRequest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(PermissionRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
