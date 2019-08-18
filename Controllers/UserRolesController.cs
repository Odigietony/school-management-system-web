using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        public UserRolesController(RoleManager<IdentityRole> roleManager,
         UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("allroles");
                }
                foreach (var errors in result.Errors)
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
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoles(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"The requested Role with Id = { model.Id } Cannot be found";
                    return View("Not Found");
                }
                else
                {
                    role.Name = model.RoleName;
                    var result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                         ViewBag.success = "The Update was successful!";
                        return Json(new { success = true });
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserRole(string Id)
        {
            ViewBag.roleId = Id;
            var role = await roleManager.FindByIdAsync(Id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"The role with Id { Id } could not be found";
                return View("NotFound");
            }
            ViewBag.roleName = role.Name;
            List<UpdateUserRoleViewModel> model = new List<UpdateUserRoleViewModel>();
            foreach(var user in userManager.Users)
            {
                UpdateUserRoleViewModel updateUserRole = new UpdateUserRoleViewModel
                {
                    UserId = user.Id,
                    Username = user.UserName
                };
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    updateUserRole.IsSelected = true;
                }
                else
                {
                    updateUserRole.IsSelected = false;
                }
                model.Add(updateUserRole);
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(List<UpdateUserRoleViewModel> model, string Id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(Id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"The Role with Id = { Id } could not be found";
                return View("NotFound");
            }
            for(int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                if(model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name); 
                }
                else if(!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                } 
                else { continue; }

                if(result.Succeeded)
                {
                    if(i < (model.Count -1))
                    {
                        continue;
                    }else
                    {  
                        return Json( new {success = true} );
                    }
                } 
            }
            return Json( new {success = false} );
        }
    }
}