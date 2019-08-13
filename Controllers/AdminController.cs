using System.Threading.Tasks;
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
        public AdminController(IEntityRepository<Admin> entityRepository, 
        UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            _entityRepository = entityRepository;
        }
        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
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