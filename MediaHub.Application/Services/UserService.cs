using MediaHub.Application.DTOs;
using MediaHub.Application.Interfaces;
using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
using MediaHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserInterface _userInterface;
        private readonly AppDbContext _appContext;
        public UserService(IUserInterface userInterface,AppDbContext appContext)
        {
            _userInterface = userInterface;
            _appContext = appContext;
        }

        public async Task<ResponseDataModel> CreateUser(CreateUserDto model)
        {
            // 1️⃣ Default Role fetch karo
            var defaultRole = await _appContext.Roles.FirstOrDefaultAsync(r => r.Name == "User");
            if (defaultRole == null)
                throw new Exception("Default role not found in DB");

            // 2️⃣ User entity create karo
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password ?? ""), // hash password
                RoleId = defaultRole.Id
            };

            // 3️⃣ Save user
            var createdUser = await _userInterface.Create(user);

            // 4️⃣ Map entity to DTO (avoid circular reference)
            var userDto = new UserResponseDto
            {
                Id = createdUser.Id,
                UserName = createdUser.UserName,
                Email = createdUser.Email,
                RoleName = defaultRole.Name
            };

            // 5️⃣ Return Response
            return new ResponseDataModel
            {
                IsSuccess = true,
                Message = "User created successfully",
                Data = userDto
            };
        }



        public async Task<ResponseDataModel> DeleteUser(long id)
        {
           var response=new ResponseDataModel();    
            var result= await _userInterface.Delete(id);
            if(!result)
            {
                response.IsSuccess=false;
                response.Message="User deletion failed";
                return response;
            }
            else
            {
                response.IsSuccess=true;
                response.Message="User deleted successfully";
                return response;
            }
        }

        public Task<ResponseDataModel> LoginUser(UserLoginDto model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDataModel> ReadUser(User model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDataModel> UpdateUser(UpdateUserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
