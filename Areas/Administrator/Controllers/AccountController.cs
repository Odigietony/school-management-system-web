using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Areas.Administrator.ViewModels;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class AccountController : Controller
    {
        
        private readonly SignInManager<IdentityUser> signinManager;
        private readonly IEntityRepository<Admin> entityRepository;
        private readonly UserManager<IdentityUser> userManager;
        public AccountController(SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager,
        IEntityRepository<Admin> entityRepository)
        {
            this.userManager = userManager;
            this.entityRepository = entityRepository;
            this.signinManager = signinManager;
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                IdentityUser adminUser = await userManager.FindByEmailAsync(model.EmailAddress);
                if(adminUser != null)
                {
                    Admin admin = entityRepository.GetByUserId(adminUser.Id);
                    if(admin == null)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login Attenpt");
                        return View(model);
                    }
                    else
                    {
                        var result = await signinManager
                        .PasswordSignInAsync(adminUser.UserName, model.Password, model.RememberMe, false);
                        if(result.Succeeded)
                        {
                            if(!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction("index", "dashboard");
                            }
                        } 
                    }
                } 
                 ModelState.AddModelError(string.Empty, "Invalid Login Attenpt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("Home/Index");
        }
    }
}