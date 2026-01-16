using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserInterface
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext appDbContext)
        {
           _context = appDbContext;
        }
        public async Task<User> Create(User model)
        {
          var user=await  _context.Users.AddAsync(model);  
            if(user!=null)
            {
                await _context.SaveChangesAsync();
              
            }
           return user.Entity;
        }

        public async Task Delete(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
           
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> LoginUser(string email, string password)
        {
          
           var userlogin=await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.PasswordHash == password);
            if (userlogin != null) 
            {
                userlogin.UserName = userlogin.UserName;
                userlogin.Email = userlogin.Email;
                userlogin.PasswordHash = userlogin.PasswordHash;
            }

        }

        public Task<User?> Read(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
