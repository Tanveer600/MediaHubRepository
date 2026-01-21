using MediaHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Domain.Interfaces
{
    public interface IRoleInterface
    {
        Task<Role> Create(Role role);   
        Task<Role> Update(Role role);   
        Task<Role> Delete(long id);   
        Task<Role ?> Read(long id);   
        Task<List<Role>> ReadRoleList();   
    }
}
