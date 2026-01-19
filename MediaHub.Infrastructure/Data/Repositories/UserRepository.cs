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

        public async Task<bool> Delete(long id)
        {
          
            {
              var userList=await  _context.Users.FindAsync(id);
                if(userList==null)
                {
                    _context.Users.Remove(userList);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
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
            return userlogin!;  

        }

        public async Task<User?> Read(long id)
        {
            return await _context.Users.FindAsync(id).AsTask();   
        }

        public async Task<User> Update(User model)
        {
           var userUpdate=await _context.Users.FirstOrDefaultAsync(x=>x.Id==model.Id);
            if(userUpdate!=null)
            {
                userUpdate.UserName = model.UserName;
                userUpdate.Email = model.Email;
                userUpdate.PasswordHash = model.PasswordHash;
                await _context.SaveChangesAsync();
            }
            return userUpdate!; 
        }
    }
}
