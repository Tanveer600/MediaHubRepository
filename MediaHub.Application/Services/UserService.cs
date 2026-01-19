using MediaHub.Application.DTOs;
using MediaHub.Application.Interfaces;
using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
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

        public async Task<ResponseDataModel> CreateUser(CreateUserDto model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.PasswordHash
            };
            var var= await _userInterface.Create(user);
            return new ResponseDataModel
            {
                IsSuccess = true,
                Message = "User created successfully",
                Data = var
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
