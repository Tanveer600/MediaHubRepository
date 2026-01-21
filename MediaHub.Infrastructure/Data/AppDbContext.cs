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
        public DbSet<Role> Roles { get; set; }



      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Media>()   // MediaType enum → string in DB
                .Property(m => m.MediaType)
                .HasConversion<string>();

            
            modelBuilder.Entity<User>()   // User → Role relationship
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Role>()     //  Unique Role Name
                .HasIndex(r => r.Name)
                .IsUnique();
            // ✅ Seed default roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }   // <- ye default role
            );
        }
       
    }
}
