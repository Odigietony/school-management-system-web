using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Areas.Administrator.ViewModels;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class LocationController : Controller
    {
        private readonly IEntityRepository<Location> locationRepository;
        private readonly IEntityRepository<LocationCategory> categoryRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        public LocationController(IEntityRepository<Location> locationRepository, SignInManager<IdentityUser> signInManager,
        IEntityRepository<LocationCategory> categoryRepository)
        {
            this.signInManager = signInManager;
            this.categoryRepository = categoryRepository;
            this.locationRepository = locationRepository;
        }

        [HttpGet]
        public IActionResult AllLocations()
        {
            AllLocationsViewModel model = new AllLocationsViewModel();
            model.Locations = locationRepository.GetAll().Include(l => l.LocationCategory);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewLocation()
        {
            AddNewLocationViewModel model = new AddNewLocationViewModel();
            GetAllCategories(model);
            return View();
        }

        [HttpPost]
        public IActionResult AddNewLocation(AddNewLocationViewModel model)
        {
            if (ModelState.IsValid)
            { 
                Location location = new Location
                {
                    Title = model.Title,
                    Number = model.Number,
                    CategoryId = model.CategoryId,
                    // AdminId = model.AdminId
                };
                locationRepository.Insert(location);
                locationRepository.Save();
                return Redirect("alllocations");
            }
            GetAllCategories(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditLocation(long Id)
        {
            var location = locationRepository.GetById(Id);
            if (location == null)
            {
                ViewBag.ErrorMessage = $"location resource with { Id } not found";
                return View("Error");
            }
            EditLocationViewModel model = new EditLocationViewModel
            {
                Title = location.Title,
                // AdminId = model.AdminId,
                Number = location.Number,
                CategoryId = location.CategoryId
            };
            GetAllCategories(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditLocation(EditLocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Location location = new Location
                {
                    Title = model.Title,
                    // AdminId = model.AdminId,
                    Number = model.Number,
                    CategoryId = model.CategoryId
                };
                locationRepository.Update(location);
                locationRepository.Save();
                return Json(new { success = true });
            }
            GetAllCategories(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Deletelocation(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The location Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            Location location = locationRepository.GetById(Id);
            if (location == null)
            {
                ViewBag.ErrorMessage = $"The location Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            locationRepository.Delete(location.Id);
            locationRepository.Save();
            return Json(new { success = true });
        }

        public AddNewLocationViewModel GetAllCategories(AddNewLocationViewModel model)
        {
            var categories = categoryRepository.GetAll();
            foreach(var category in categories)
            {
                model.Categories.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.Title });
            }
            return model;
        }

        public IActionResult AllCategories()
        {
            AllCategories model = new AllCategories();
            model.Categories = categoryRepository.GetAll();
            return View(model);
        }

        public IActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(AddNewCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                LocationCategory category = new LocationCategory
                {
                    Title = model.Title
                };
                categoryRepository.Insert(category);
                categoryRepository.Save();
                return Redirect("allcategories");
            }
            return View(model);
        }

         [HttpGet]
        public IActionResult EditCategory(long Id)
        {
            var location = locationRepository.GetById(Id);
            if (location == null)
            {
                ViewBag.ErrorMessage = $"location resource with { Id } not found";
                return View("Error");
            }
            EditCategoryViewModel model = new EditCategoryViewModel
            {
                Title = location.Title,
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditCategory(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Location location = new Location
                {
                    Title = model.Title,
                };
                locationRepository.Update(location);
                locationRepository.Save();
                return Json(new { success = true });
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteCategory(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The location Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            LocationCategory category = categoryRepository.GetById(Id);
            if (category == null)
            {
                ViewBag.ErrorMessage = $"The category Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            categoryRepository.Delete(category.Id);
            categoryRepository.Save();
            return Json(new { success = true });
        }

    }
}