using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MediaHub.Application.DTOs.Auth.Auth;

namespace MediaHub.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDataModel> Register(RegisterDto dto);
        Task<ResponseDataModel> Login(LoginDto dto);
    }
}
