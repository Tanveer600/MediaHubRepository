using MediaHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Domain.Interfaces
{
    public interface IUserInterface
    {
        Task<User> Create(User model);
        Task<User?> Read(long id);
        Task<User> Update(User model);
        Task Delete(long id);
        Task<List<User>> GetAll();
        Task<User> LoginUser(string email, string password);    

    }
}
