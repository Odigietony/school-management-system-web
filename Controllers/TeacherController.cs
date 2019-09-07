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
        private readonly IStateRepository stateRepository;
        Random random = new Random();
        public TeacherController(ITeacherRepository teacherRepository, ICountryRepository countryRepository,
        UserManager<IdentityUser> userManager, IPasswordGenerator passwordGenerator, IProcessFileUpload processFileUpload,
        IStateRepository stateRepository)
        {
            this.processFileUpload = processFileUpload;
            this.passwordGenerator = passwordGenerator;
            this.countryRepository = countryRepository;
            this.userManager = userManager;
            this.stateRepository = stateRepository;
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
            ListOfCountries(model);
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
            ListOfCountries(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditTeacherData(long Id)
        {
            Teacher teacher = _teacherRepository.GetTeacherById(Id);
            if(teacher == null)
            {
                ViewBag.ErrorMessage = $"The Teacher with Id = { Id } could not be found!";
                return View("NotFound");
            } 
            IdentityUser user = await userManager.FindByIdAsync(teacher.IdentityUserId);
            TeacherContactInformation contactInformation = _teacherRepository.GetTeacherContactInfoById(teacher.Id);
            TeacherHighestDegree highestDegree = _teacherRepository.GetTeacherHighestDegree(contactInformation.Id);
            TeacherOtherDegree otherDegree = _teacherRepository.GetTeacherOtherDegree(highestDegree.Id);
            State state = stateRepository.GetRelatedCountry(contactInformation.CountryId);
            EditTeacherViewModel model = new EditTeacherViewModel
            {
                // Personal Information
                Id = teacher.Id,
                IdentityUser = user,
                Firstname = teacher.Firstname,
                Middlename = teacher.Middlename,
                Lastname = teacher.Lastname,
                Gender = teacher.Gender,
                DateOfBirth = Convert.ToDateTime(teacher.DateOfBirth),
                PhoneNumber = teacher.PhoneNumber,
                EmailAddress = teacher.EmailAddress,

                //Contact Information
                Address1 = contactInformation.Address1,
                Address2 = contactInformation.Address2,
                CountryId = contactInformation.CountryId,
                StateId = state.Id,
                ZipCode = contactInformation.ZipCode,
                HomePhone = contactInformation.HomePhone,
                MobilePhone = contactInformation.MobilePhone,
                AlternateEmailAddress = contactInformation.AlternateEmailAddress,

                // Next of Kin information
                NextOfKinFirstname = contactInformation.NextOfKinFirstname,
                NextOfKinLastname = contactInformation.NextOfKinLastname,
                RelationToNextOfKin = contactInformation.RelationToNextOfKin,
                PhoneOfNextOfKin = contactInformation.PhoneOfNextOfKin,
                EmailOfNextOfKin = contactInformation.EmailOfNextOfKin,

                // Accademic information
                // == Highest degree information == //
                NameOfInstitution = highestDegree.NameOfInstitution,
                YearEnrolled = Convert.ToDateTime(highestDegree.YearEnrolled),
                YearOfGraduation = Convert.ToDateTime(highestDegree.YearOfGraduation),
                CGPA = highestDegree.CGPA,
                DegreeAttained = highestDegree.DegreeAttained,

                // == Other degree information == //
                OtherNameOfInstitution = otherDegree.NameOfInstitution,
                YearOfEnrollement = Convert.ToDateTime(otherDegree.YearOfEnrollement),
                OtherYearOfGraduation = Convert.ToDateTime(otherDegree.YearOfGraduation),
                OtherDegreeAttained = otherDegree.DegreeAttained,
                OtherCGPA = otherDegree.CGPA 
            };
            States(model);
            return View(model);
        }

        

        public JsonResult AjaxGetStates(long countryId)
        {
            List<State> states = new List<State>(countryRepository.GetRelatedStates(countryId));
            states.Insert(0, new State { Id = 0, StateName = "----- Select a State -----" });
            return Json(new SelectList(states, "Id", "StateName"));
        }

        private AddTeacherViewModel ListOfCountries(AddTeacherViewModel model)
        {
            var countries = countryRepository.GetAllCountries();
            foreach (var country in countries)
            {
                model.Countries.Add(new SelectListItem { Text = country.CountryName, Value = country.Id.ToString() });
            }
            return model;
        }
        private AddTeacherViewModel States(AddTeacherViewModel model)
        {
            ListOfCountries(model);
            var states =  countryRepository.GetRelatedStates(model.CountryId);
            foreach(var state in states)
            {
                model.States.Add(new SelectListItem { Text = state.StateName, Value = state.Id.ToString() });
            } 
           return model;
        }

  } 
}