using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data
{
    public static class ModelBuilderExtension
    {
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1",
                    UserName = "SuperAdmin",
                    Email = "superadmin@gmail.com",
                    PasswordHash = "SuperAdmin"
                }
            );
        }

        public static void SeedAdmin(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Firstname = "Anthony", 
                    Lastname = "Russo",
                    IdentityUserId = "1",
                    
                }
            );
        }
    }
}