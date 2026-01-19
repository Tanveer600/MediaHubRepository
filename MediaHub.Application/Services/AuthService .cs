using MediaHub.Application.DTOs.Auth;
using MediaHub.Application.Interfaces;
using MediaHub.Domain.Entities;
using MediaHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static MediaHub.Application.DTOs.Auth.Auth;

namespace MediaHub.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //  REGISTER
        public async Task<ResponseDataModel> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(x => x.Email == dto.Email))
                return new ResponseDataModel { IsSuccess = false, Message = "Email already exists" };

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ResponseDataModel
            {
                IsSuccess = true,
                Message = "User registered successfully"
            };
        }

        //  LOGIN
        public async Task<ResponseDataModel> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return new ResponseDataModel { IsSuccess = false, Message = "Invalid credentials" };

            var token = GenerateJwtToken(user);

            return new ResponseDataModel
            {
                IsSuccess = true,
                Data = token,
                Message = "Login successful"
            };
        }

       
        //  JWT TOKEN
        private AuthResponseDto GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("uid", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(
                int.Parse(_config["Jwt:DurationInMinutes"]!)
            );

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireAt = expires,
                Role = user.Role.Name
            };
        }
    }
}
