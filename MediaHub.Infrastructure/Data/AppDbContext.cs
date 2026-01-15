using MediaHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Infrastructure.Data
{
    public class AppDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            :base(options)
        {            
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Media> MediaItems { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
