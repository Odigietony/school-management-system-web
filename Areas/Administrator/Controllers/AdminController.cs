using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Helpers;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Areas.Administrator.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SchoolManagementSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IEntityRepository<Admin> _entityRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPasswordGenerator passwordGenerator;
        private readonly IProcessFileUpload processFileUpload;
        Random random = new Random();
        public AdminController(IEntityRepository<Admin> entityRepository,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
        IHostingEnvironment hostingEnvironment, IPasswordGenerator passwordGenerator, IProcessFileUpload processFileUpload)
        {
            this.processFileUpload = processFileUpload;
            this.hostingEnvironment = hostingEnvironment;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.passwordGenerator = passwordGenerator;
            _entityRepository = entityRepository;
        }
        
    public ViewResult Index()
    {
        var model = _entityRepository.GetAll().Include(a => a.IdentityUser);
        return View(model);
    }

    // [Authorize(AuthenticationSchemes = "frontend")]
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
            string uniqueFileName = processFileUpload.UploadImage(model.Image);
            string generatedPassword = passwordGenerator.GeneratePassword(15);
            var role = await roleManager.FindByIdAsync(model.Role.Id); 
                IdentityUser user = new IdentityUser
                {
                    UserName = passwordGenerator.GenerateUsernameFromEmail(model.EmailAddress),
                    Email = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                };
                IdentityResult result = await userManager.CreateAsync(user, generatedPassword);
                if (result.Succeeded)
                {
                    IdentityResult roleAddedResult = await userManager.AddToRoleAsync(user, role.Name);
                    if (roleAddedResult.Succeeded)
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

    [HttpGet]
    public async Task<IActionResult> Edit(long Id)
    {
        var admin = _entityRepository.GetById(Id);
        var adminIdentityUser = await userManager.FindByIdAsync(admin.IdentityUserId);
        admin.IdentityUser = adminIdentityUser;

        if (admin == null)
        {
            ViewBag.ErrorMessage = $"The Admin with Id = { Id  } could not be found.";
            return View("NotFound");
        }
        EditAdminViewModel model = new EditAdminViewModel
        {
            Id = admin.Id,
            Firstname = admin.Firstname,
            Lastname = admin.Lastname,
            EmailAddress = admin.IdentityUser.Email,
            ExistingPhotoPath = admin.ImagePath,
            PhoneNumber = admin.IdentityUser.PhoneNumber,
            Username = admin.IdentityUser.UserName,
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditAdminViewModel model)
    {
        if (ModelState.IsValid)
        {
            Admin admin = _entityRepository.GetById(model.Id);
            IdentityUser user = await userManager.FindByIdAsync(admin.IdentityUserId);
            if (admin == null || user == null)
            {
                ViewBag.ErrorMessage = "The Resource couldn't be found";
                return View("NotFound");
            }

            admin.Firstname = model.Firstname;
            admin.Lastname = model.Lastname;
            user.Email = model.EmailAddress;
            user.PhoneNumber = model.PhoneNumber;
            if(user.Email != model.EmailAddress)
            {
                user.UserName = passwordGenerator.GenerateUsernameFromEmail(model.EmailAddress);
            } 
            
            
            if (model.Image != null)
            {
                if (model.ExistingPhotoPath != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", model.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                }
                admin.ImagePath = processFileUpload.UploadImage(model.Image);
            }
            IdentityResult result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                _entityRepository.Update(admin);
                _entityRepository.Save();
                return RedirectToAction("index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(long Id)
    {
        Admin admin = _entityRepository.GetById(Id);
        IdentityUser adminUser = await userManager.FindByIdAsync(admin.IdentityUserId);
        admin.IdentityUser = adminUser;
        if (admin == null)
        {
            ViewBag.ErrorMessage = $"The admin with Id = { Id } could not be found";
            return View("NotFound");
        }
        AdminDetailsViewModel model = new AdminDetailsViewModel();
        model.Admin = admin;
        foreach (var role in roleManager.Roles)
        {
            if (await userManager.IsInRoleAsync(admin.IdentityUser, role.Name))
            {
                model.Roles.Add(role.Name);
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long Id)
    {
        Admin admin = _entityRepository.GetById(Id); 
        if (admin == null)
        {
            ViewBag.ErrorMessage = $"The admin resource with Id = { Id } could not be found";
            return View("NotFound");
        }
        IdentityUser adminUser = await userManager.FindByIdAsync(admin.IdentityUserId);
        if (adminUser == null)
        {
            ViewBag.ErrorMessage = $"The admin resource with Id = { admin.IdentityUserId } could not be found";
            return View("NotFound");
        } 
        IdentityResult result = await userManager.DeleteAsync(adminUser);
        if (result.Succeeded)
        {
            if(admin.ImagePath != null)
            {
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", admin.ImagePath);
                System.IO.File.Delete(filePath);
            }
            _entityRepository.Delete(admin.Id);
            _entityRepository.Save();
            return Json(new { success = true });
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View("index");
        }
    } 

    [AcceptVerbs("Get", "Post")]
    [AllowAnonymous]
    public async Task<IActionResult> IsEmailInUse(string EmailAddress)
    {
        IdentityUser user = await userManager.FindByEmailAsync(EmailAddress);
        return user == null ? Json(true) : Json($"Email: { EmailAddress } is already in use.");
    }


}
}