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
using System.IO;
using Microsoft.AspNetCore.Hosting;

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
        private readonly IHostingEnvironment hostingEnvironment;
        Random random = new Random();
        public TeacherController(ITeacherRepository teacherRepository, ICountryRepository countryRepository,
        UserManager<IdentityUser> userManager, IPasswordGenerator passwordGenerator, IProcessFileUpload processFileUpload, 
        IStateRepository stateRepository, IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
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
            if (result.Succeeded)
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
            foreach (var error in result.Errors)
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
        if (teacher == null)
        {
            ViewBag.ErrorMessage = $"The Teacher with Id = { Id } could not be found!";
            return View("NotFound");
        }
        IdentityUser user = await userManager.FindByIdAsync(teacher.IdentityUserId);
        TeacherContactInformation contactInformation = _teacherRepository.GetTeacherContactInfoById(teacher.Id);
        TeacherHighestDegree highestDegree = _teacherRepository.GetTeacherHighestDegreeById(contactInformation.Id);
        TeacherOtherDegree otherDegree = _teacherRepository.GetTeacherOtherDegreeById(highestDegree.Id);
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
            ExistingPhotoPath = teacher.ProfilePhotoPath,

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

    [HttpPost]
    public async Task<IActionResult> EditTeacherData(EditTeacherViewModel model)
    {
        if (ModelState.IsValid)
        {
            Teacher teacher = _teacherRepository.GetTeacherById(model.Id);
            if (teacher == null)
            {
                ViewBag.ErrorMessage = $"The teacher with Id = { model.Id } could not be found";
                return View("NotFound");
            }
            IdentityUser user = await userManager.FindByIdAsync(teacher.IdentityUserId);
            user.Email = model.EmailAddress;
            user.PhoneNumber = model.PhoneNumber;
            IdentityResult result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                // Update Teacher personal information
                teacher.Firstname = model.Firstname;
                teacher.Middlename = model.Middlename;
                teacher.Lastname = model.Lastname;
                teacher.Gender = model.Gender;
                teacher.DateOfBirth = model.DateOfBirth.ToString();
                teacher.PhoneNumber = model.PhoneNumber;
                teacher.EmailAddress = model.EmailAddress;
                teacher.Religion = model.Religion; 
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    teacher.ProfilePhotoPath = processFileUpload.UploadImage(model.Photo);
                }
                _teacherRepository.UpdateTeacherData(teacher);


                // Update Teacher contact information
                TeacherContactInformation contactInformation = _teacherRepository.GetTeacherContactInfoById(teacher.Id);
                contactInformation.Address1 = model.Address1;
                contactInformation.Address2 = model.Address2;
                contactInformation.AlternateEmailAddress = model.AlternateEmailAddress;
                contactInformation.ZipCode = model.ZipCode;
                contactInformation.HomePhone = model.HomePhone;
                contactInformation.MobilePhone = model.MobilePhone;
                contactInformation.NextOfKinFirstname = model.NextOfKinFirstname;
                contactInformation.NextOfKinLastname = model.NextOfKinLastname;
                contactInformation.RelationToNextOfKin = model.RelationToNextOfKin;
                contactInformation.PhoneOfNextOfKin = model.PhoneOfNextOfKin;
                contactInformation.EmailOfNextOfKin = model.EmailOfNextOfKin;
                contactInformation.CountryId = model.CountryId;
                _teacherRepository.UpdateTeacherContactData(contactInformation);


                // Update Teacher highest degree information
                TeacherHighestDegree highestDegree = _teacherRepository.GetTeacherHighestDegreeById(contactInformation.Id);
                highestDegree.NameOfInstitution = model.NameOfInstitution;
                highestDegree.YearEnrolled = model.YearEnrolled.ToString();
                highestDegree.YearOfGraduation = model.YearOfGraduation.ToString();
                highestDegree.DegreeAttained = model.DegreeAttained;
                highestDegree.CGPA = model.CGPA;
                _teacherRepository.UpdateTeacherHighestDegreeData(highestDegree);

                // Update teacher other degree information
                TeacherOtherDegree otherDegree = _teacherRepository.GetTeacherOtherDegreeById(highestDegree.Id);
                otherDegree.NameOfInstitution = model.OtherNameOfInstitution;
                otherDegree.YearOfEnrollement = model.YearOfEnrollement.ToString();
                otherDegree.YearOfGraduation = model.OtherYearOfGraduation.ToString();
                otherDegree.DegreeAttained = model.OtherDegreeAttained;
                otherDegree.CGPA = model.OtherCGPA;
                _teacherRepository.UpdateTeacherOtherDegreeData(otherDegree);
                return RedirectToAction("allteachers");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> TeacherDetails(long Id)
    {
        Teacher teacher = _teacherRepository.GetTeacherById(Id);
        IdentityUser user = await userManager.FindByIdAsync(teacher.IdentityUserId);
        teacher.IdentityUser = user;
        if(teacher == null)
        {
            ViewBag.ErrorMessage = $"The Teacher with Id = { Id } could not be found.";
            return View("NotFound");
        }
        var contactInformation = _teacherRepository.GetTeacherContactInfoById(teacher.Id);
        var highestDegree = _teacherRepository.GetTeacherHighestDegreeById(contactInformation.Id);
        var otherDegree = _teacherRepository.GetTeacherOtherDegreeById(highestDegree.Id);
        TeacherDetailsViewModel model = new TeacherDetailsViewModel
        {
            Teacher = teacher,
            TeacherContactInformation = contactInformation,
            TeacherHighestDegree = highestDegree,
            TeacherOtherDegree = otherDegree
        };
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
        var states = countryRepository.GetRelatedStates(model.CountryId);
        foreach (var state in states)
        {
            model.States.Add(new SelectListItem { Text = state.StateName, Value = state.Id.ToString() });
        }
        return model;
    }

} 
}