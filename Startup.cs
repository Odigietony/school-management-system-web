using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Helpers;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddMvc(options => {
            //     var policy = new AuthorizationPolicyBuilder()
            //     .RequireAuthenticatedUser()
            //     .Build();
            // options.Filters.Add(new AuthorizeFilter(policy));
            // });
            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); 
            services.AddDbContextPool<AppDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("SchoolManagementDB"))
            );
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>(); 
            
           services.ConfigureApplicationCookie(options =>{
               options.LoginPath = "/Administrator/Account/Login";
               options.Cookie.IsEssential = true;
           });
            services.AddMvc();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IEntityRepository<Admin>, EntityRepository<Admin>>();
            services.AddTransient<IEntityRepository<AdminTask>, EntityRepository<AdminTask>>();
            services.AddTransient<IEntityRepository<Faculty>, EntityRepository<Faculty>>();
            services.AddTransient<IEntityRepository<Department>, EntityRepository<Department>>();
            services.AddTransient<IEntityRepository<CourseYear>, EntityRepository<CourseYear>>();
            services.AddTransient<IEntityRepository<Course>, EntityRepository<Course>>();
            services.AddTransient<ILocation, LocationRepository>();
            services.AddTransient<IEntityRepository<LocationCategory>, EntityRepository<LocationCategory>>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddScoped<IPasswordGenerator, PasswordGenerator>();
            services.AddScoped<IProcessFileUpload, ProcessUploadFile>();
            services.AddTransient<IStateRepository, StateRepository>(); 
            services.AddTransient<ITaskRepository, TaskRepository>(); 
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error");
            }
            
            
          
            app.UseStaticFiles(); 
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Administrator",
                    template: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                );
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            }); 
        }
    }
}
