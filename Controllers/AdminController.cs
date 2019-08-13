using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
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
        public AdminController(IEntityRepository<Admin> entityRepository,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, 
        IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.roleManager = roleManager;
            this.userManager = userManager;
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
            string[] username = model.EmailAddress.ToString().Split("@");
            string generatedPassword = Guid.NewGuid().ToString().Substring(0, 8);
            IdentityUser user = new IdentityUser 
            { 
                UserName = username[1], 
                Email = model.EmailAddress, 
                PhoneNumber = model.PhoneNumber,
            };
            IdentityResult result = await userManager.CreateAsync(user, generatedPassword);
            if(result.Succeeded)
            {
                IdentityResult roleAddedResult =await userManager.AddToRoleAsync(user, model.Role.Name);
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

    [AcceptVerbs("Get", "Post")]
    public async Task<IActionResult> IsEmailInUse(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return Json(true);
        }
        else
        {
            return Json(false);
        }
    }
}
}