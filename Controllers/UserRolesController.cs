using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public UserRolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager; 
        }

        [HttpGet]
        public IActionResult AllRoles()
        {
            AllRolesViewModel roles = new AllRolesViewModel
            {
                Roles = roleManager.Roles
            };
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRoles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoles(AddRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                var result = await roleManager.CreateAsync(role); 
                if(result.Succeeded)
                {
                    return RedirectToAction("allroles");
                }
                foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errors.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<PartialViewResult> EditRoles(string Id)
        {
            var roles = await roleManager.FindByIdAsync(Id);
            //Check if the id/role exists.
            EditRoleViewModel model = new EditRoleViewModel 
            {
                Id = roles.Id,
                RoleName = roles.Name
            };
            return PartialView("_EditRolePartialView", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoles(EditRoleViewModel model, string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"The requested Role with Id = { Id } Cannot be found";
                return View("Not Found");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("allroles");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Json(model);
        }
    }
}