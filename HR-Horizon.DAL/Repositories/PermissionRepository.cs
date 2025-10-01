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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(PermissionRequest Request)
        {
           await _context.PermissionRequests.AddAsync(Request);
           return await _context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PermissionRequest> GetAllAsync()
        {
           return _context.PermissionRequests;
        }

        public Task<PermissionRequest?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(PermissionRequest Request)
        {
            throw new NotImplementedException();
        }
    }
}
