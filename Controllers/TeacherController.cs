using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IEntityRepository<Teacher> _entityRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICountryRepository countryRepository;
        public TeacherController(IEntityRepository<Teacher> entityRepository, ICountryRepository countryRepository,
        UserManager<IdentityUser> userManager)
        {
            this.countryRepository = countryRepository;
            this.userManager = userManager;
            _entityRepository = entityRepository;
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            AddTeacherViewModel model = new AddTeacherViewModel();
            var countries = countryRepository.GetAllCountries();
            foreach(var country in countries)
            {
                model.Countries.Add(new SelectListItem { Text = country.CountryName, Value = country.Id.ToString() });
            }
            return View(model);
        }
    }
}