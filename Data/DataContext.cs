using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<Blogs> Blogs { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Blogs)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);

            // Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "user", NormalizedName = "USER" }
            );

            // Seed admin user
            var adminUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var User = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123"); 
            User.PasswordHash = passwordHasher.HashPassword(User, "User@123");

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);

            // Assign roles to the admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" } 
            );


        }
    }
    }
