using MediaHub.Application.DTOs;
using MediaHub.Application.Interfaces;

using MediaHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;  
        }
        [HttpPost("create")]
        public async Task<IActionResult> Save([FromBody] CreateUserDto user)
        {
          var result=  await _userService.CreateUser(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] long id)
        {
            var deleteuser = await _userService.DeleteUser(id);
            return deleteuser.IsSuccess ? Ok(deleteuser) : BadRequest(deleteuser);
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto user)
        {
            var result = await _userService.UpdateUser(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("read")]
        public async Task<IActionResult> ReadUser(User user)
        {
            var result = await _userService.ReadUser(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
