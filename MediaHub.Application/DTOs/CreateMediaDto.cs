using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Domain.Enums;

namespace MediaHub.Application.DTOs
{
    public class CreateMediaDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public MediaType MediaType { get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
    }
}
