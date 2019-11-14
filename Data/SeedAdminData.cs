using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data
{
    public static class SeedAdminData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        { 
            using(var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if(context.Users.Any())
                {
                    return;
                }
                else
                {
                    var roleManager = new RoleStore<IdentityRole>(context);
                    var userManager = new UserStore<IdentityUser>(context);
                    var user = new IdentityUser()
                    {
                        UserName = "SuperAdmin",
                        NormalizedUserName = "SUPERADMIN",
                        Email = "superadmin@gmail.com",
                        NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PhoneNumber = "1234567890",
                        PhoneNumberConfirmed = true,
                    };

                    
                    if(!context.Roles.Any())
                    {
                        roleManager.CreateAsync(new IdentityRole{
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                        user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, "OwnerOfApp");
                        userManager.CreateAsync(user);
                        userManager.AddToRoleAsync(user, "Administrator");
                    }
                    context.Admins.Add(new Admin{
                        Firstname = "Anthony", 
                        Lastname = "JR",
                        IdentityUserId = user.Id
                    });
                    context.SaveChanges();
                }
            }
        }
      
    }
}