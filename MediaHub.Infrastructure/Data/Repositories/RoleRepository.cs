using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Infrastructure.Data.Repositories
{
    public class RoleRepository : IRoleInterface
    {
        private readonly AppDbContext _context;
        public async Task<Role> Create(Role role)
        {
        var result= await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public Task<Role> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Role?> Read(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> ReadRoleList()
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
