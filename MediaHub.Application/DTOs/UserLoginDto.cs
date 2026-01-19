using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Application.DTOs
{
    public class UserLoginDto
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
    }
}
