using MediaHub.Domain.Common;
using MediaHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Domain.Entities
{
    public class Media:BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }  // path on server/cloud
        public MediaType? MediaType { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public long CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
