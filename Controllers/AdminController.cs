using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Helpers;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEntityRepository<Admin> _entityRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPasswordGenerator passwordGenerator;
        Random random = new Random();
        public AdminController(IEntityRepository<Admin> entityRepository,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, 
        IHostingEnvironment hostingEnvironment, IPasswordGenerator passwordGenerator)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.passwordGenerator = passwordGenerator;
            _entityRepository = entityRepository;
        }
    public ViewResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        List<IdentityRole> list = new List<IdentityRole>();
        list = roleManager.Roles.ToList();
        ViewBag.list = list;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAdminViewModel model)
    {
        if (ModelState.IsValid)
        {
            string uniqueFileName = ProcessFileThenUpload(model);
            string[] usernameChars = model.EmailAddress.ToString().Split("@");
            string username = usernameChars[0].ToString();
            string generatedPassword = passwordGenerator.GeneratePassword(15);
            var role = await roleManager.FindByIdAsync(model.Role.Id);
            IdentityUser user = new IdentityUser 
            { 
                UserName = username + random.Next(100, 999), 
                Email = model.EmailAddress, 
                PhoneNumber = model.PhoneNumber,
            };
            IdentityResult result = await userManager.CreateAsync(user, generatedPassword);
            if(result.Succeeded)
            {
                IdentityResult roleAddedResult =await userManager.AddToRoleAsync(user, role.Name);
                if(roleAddedResult.Succeeded)
                {
                    Admin admin = new Admin
                    {
                        Firstname = model.Firstname,
                        Lastname = model.Lastname,
                        ImagePath = uniqueFileName,
                        IdentityUserId = user.Id
                    };
                    _entityRepository.Insert(admin);
                    _entityRepository.Save();
                    return RedirectToAction("index");
                }
               foreach (var error in roleAddedResult.Errors)
               {
                   ModelState.AddModelError(string.Empty, error.Description);
               }   
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    private string ProcessFileThenUpload(CreateAdminViewModel model)
    {
        string uniqueFileName = null;
        if (model.Image != null)
        {
            string folderPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            uniqueFileName = Guid.NewGuid() + "_" + model.Image.FileName;
            string filePath = Path.Combine(folderPath, uniqueFileName);
            using(var filestream = new FileStream(filePath, FileMode.Create))
            {
                model.Image.CopyTo(filestream);
            }
        }
        return uniqueFileName;
    }

    
}
}