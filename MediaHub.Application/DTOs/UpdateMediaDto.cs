using MediaHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Application.DTOs
{
    public class UpdateMediaDto
    {
        public long id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public MediaType MediaType { get; set; }
        public long UserId { get; set; }
        public long CategoryId { get; set; }
    }
}
