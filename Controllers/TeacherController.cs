using System; 
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Helpers;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SchoolManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICountryRepository countryRepository;
        private readonly IPasswordGenerator passwordGenerator;
        private readonly IProcessFileUpload processFileUpload;
        Random random = new Random();
        public TeacherController(ITeacherRepository teacherRepository, ICountryRepository countryRepository,
        UserManager<IdentityUser> userManager, IPasswordGenerator passwordGenerator, IProcessFileUpload processFileUpload)
        {
            this.processFileUpload = processFileUpload;
            this.passwordGenerator = passwordGenerator;
            this.countryRepository = countryRepository;
            this.userManager = userManager;
            _teacherRepository = teacherRepository;
        }

        public IActionResult AllTeachers()
        {
            var model = _teacherRepository.GetAllTeacherData();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            AddTeacherViewModel model = new AddTeacherViewModel();
            var countries = countryRepository.GetAllCountries();
            foreach (var country in countries)
            {
                model.Countries.Add(new SelectListItem { Text = country.CountryName, Value = country.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(AddTeacherViewModel model)
        {
            if (ModelState.IsValid)
            { 
                IdentityUser user = new IdentityUser
                {
                    UserName = passwordGenerator.GenerateUsernameFromEmail(model.EmailAddress),
                    Email = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber
                };
                IdentityResult result = await userManager.CreateAsync(user, passwordGenerator.GeneratePassword(15));
                if(result.Succeeded)
                {
                    Teacher teacher = new Teacher
                    {
                        Firstname = model.Firstname,
                        Middlename = model.Middlename,
                        Lastname = model.Lastname,
                        Gender = model.Gender,
                        DateOfBirth = model.DateOfBirth.ToString(),
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.EmailAddress,
                        Religion = model.Religion,
                        ProfilePhotoPath = processFileUpload.UploadImage(model.Photo),
                        IdentityUserId = user.Id 
                    };
                    _teacherRepository.InsertAndSaveTeacherData(teacher);
                    TeacherContactInformation contactInformation = new TeacherContactInformation
                    {
                        Address1 = model.Address1,
                        Address2 = model.Address2,
                        AlternateEmailAddress = model.AlternateEmailAddress,
                        ZipCode = model.ZipCode,
                        HomePhone = model.HomePhone,
                        MobilePhone = model.MobilePhone,
                        NextOfKinFirstname = model.NextOfKinFirstname,
                        NextOfKinLastname = model.NextOfKinLastname,
                        RelationToNextOfKin = model.RelationToNextOfKin,
                        PhoneOfNextOfKin = model.PhoneOfNextOfKin,
                        EmailOfNextOfKin = model.EmailOfNextOfKin,
                        TeacherId = teacher.Id,
                        CountryId = model.CountryId
                    };
                    _teacherRepository.InsertContactData(contactInformation);
                    TeacherHighestDegree highestDegree = new TeacherHighestDegree
                    {
                        NameOfInstitution = model.NameOfInstitution,
                        YearEnrolled = model.YearEnrolled.ToString(),
                        YearOfGraduation = model.YearOfGraduation.ToString(),
                        DegreeAttained = model.DegreeAttained,
                        CGPA = model.CGPA,
                        TeacherContactInfoId = contactInformation.Id
                    };
                    _teacherRepository.InsertAndSaveHighestDegree(highestDegree);
                    TeacherOtherDegree otherDegree = new TeacherOtherDegree
                    {
                        NameOfInstitution = model.OtherNameOfInstitution,
                        YearOfEnrollement = model.YearOfEnrollement.ToString(),
                        YearOfGraduation = model.OtherYearOfGraduation.ToString(),
                        DegreeAttained = model.OtherDegreeAttained,
                        CGPA = model.OtherCGPA,
                        TeacherHighestDegreeId = highestDegree.Id
                    };  
                    _teacherRepository.InsertAndSaveOtherDegree(otherDegree);
                    return RedirectToAction("allteachers");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            var countries = countryRepository.GetAllCountries();
            foreach (var country in countries)
            {
                model.Countries.Add(new SelectListItem { Text = country.CountryName, Value = country.Id.ToString() });
            }
            return View(model);
        }

        public JsonResult AjaxGetStates(long countryId)
        {
            List<State> states = new List<State>(countryRepository.GetRelatedStates(countryId));
            states.Insert(0, new State { Id = 0, StateName = "----- Select a State -----" });
            return Json(new SelectList(states, "Id", "StateName"));
        }

  } 
}