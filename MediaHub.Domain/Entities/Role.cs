using MediaHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = null!; // Admin, User, Manager

        // Navigation
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
