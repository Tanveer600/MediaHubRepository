using MediaHub.Application.DTOs;
using MediaHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDataModel> LoginUser(UserLoginDto model);
        Task<ResponseDataModel> CreateUser(CreateUserDto model);
        Task<ResponseDataModel> DeleteUser(long id);
        Task<ResponseDataModel> ReadUser(User model);
        Task<ResponseDataModel> UpdateUser(UpdateUserDto model);
    }
}
