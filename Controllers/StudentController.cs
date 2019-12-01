using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Helpers;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IProcessFileUpload processFileUpload;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IPasswordGenerator passwordGenerator;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IEntityRepository<Faculty> facultyRepository;
        private readonly IEntityRepository<Department> departmentRepository;
        private readonly IEntityRepository<CourseYear> courseYearRepo;
        public StudentController(IStudentRepository studentRepository, IEntityRepository<CourseYear> courseYearRepo,
        IEntityRepository<Faculty> facultyRepository, IEntityRepository<Department> departmentRepository,
        IHostingEnvironment hostingEnvironment, IPasswordGenerator passwordGenerator,
        IProcessFileUpload processFileUpload, UserManager<IdentityUser> userManager)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.passwordGenerator = passwordGenerator;
            this.userManager = userManager;
            this.processFileUpload = processFileUpload;
            this.studentRepository = studentRepository;
            this.facultyRepository = facultyRepository;
            this.departmentRepository = departmentRepository;
            this.courseYearRepo = courseYearRepo;
        }

        [HttpGet]
        public IActionResult AllStudents()
        {
            var model = studentRepository.FindAllStudent()
                        .Include(s => s.IdentityUser).Include(s =>s.CourseYear);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            AddStudentViewModel model = new AddStudentViewModel();
            ListAllFaculties(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentViewModel model)
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
                string uniqueName = processFileUpload.UploadImage(model.Image, "uploads");
                Student student = new Student
                {
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    Lastname = model.Lastname,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth.ToLongDateString(),
                    PhoneNumber = model.PhoneNumber,
                    AlternateEmailAddress = model.AlternateEmailAddress,
                    EmailAddress = model.EmailAddress,
                    Religion = model.Religion,
                    MaritalStatus = model.MaritalStatus,
                    ResidentialAddress = model.ResidentialAddress,
                    ContactAddress = model.ContactAddress,
                    AlternatePhoneNumber = model.AlternatePhoneNumber,
                    IdentityUserId = user.Id,
                    DepartmentId = model.DepartmentId,
                    CourseYearId = SetStudentCurrentYear(model.PreviousLevel.Value.ToString()),
                    ProfilePhotoPath = uniqueName,
                    MatriculationNumber = SetMatriculationNumber(model.FacultyId, model.DepartmentId)
                };
                studentRepository.InsertStudent(student);
                studentRepository.Save();
                StudentAccademicInformation accademicInformation = new StudentAccademicInformation
                {
                    NameOfInstitution = model.NameOfInstitution,
                    YearEnrolled = model.YearEnrolled.ToLongDateString(),
                    YearOfGraduation = model.YearOfGraduation.ToLongDateString(),
                    PreviousLevel = model.PreviousLevel,
                    StudentId = student.Id
                };
                studentRepository.InsertStudentAccademicInformation(accademicInformation);
                studentRepository.Save();
                StudentNextOfKinInformation nextOfKinInformation = new StudentNextOfKinInformation
                {
                    NextOfKinFirstname = model.NextOfKinFirstname,
                    NextOfKinLastname = model.NextOfKinLastname,
                    RelationToNextOfKin = model.RelationToNextOfKin,
                    PhoneOfNextOfKin = model.PhoneOfNextOfKin,
                    EmailOfNextOfKin = model.EmailOfNextOfKin,
                    StudentId = student.Id
                };
                studentRepository.InsertStudentNextOfKin(nextOfKinInformation);
                studentRepository.Save();
                StudentSponsor studentSponsor = new StudentSponsor
                {
                    SponsorFirstname = model.SponsorFirstname,
                    SponsorMiddlename = model.SponsorMiddlename,
                    SponsorLastname = model.SponsorLastname,
                    SponsorEmailAddress = model.SponsorEmailAddress,
                    SponsorPhoneNumber = model.SponsorPhoneNumber,
                    SponsorContactAddress = model.SponsorContactAddress,
                    SponsorProffession = model.SponsorProffession,
                    SponsorWorkAddress = model.SponsorWorkAddress,
                    StudentId = student.Id
                };
                SetStudentCourses(student.Id, student.DepartmentId, student.CourseYearId);
                studentRepository.InsertStudentSponsor(studentSponsor);
                studentRepository.Save();
                
                return Redirect("allstudents");
            }
            ListAllFaculties(model);
            ListAllDepartments(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateStudentData(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The Id = { Id } could not be matched to any resource";
                return View("NotFound");
            }
            Student student = studentRepository.FindStudentById(Id);
            StudentAccademicInformation accademicInformation = studentRepository.FindStudentAccademicInformationById(student.Id);
            StudentNextOfKinInformation nextOfKinInformation = studentRepository.FindStudentNextofKinById(student.Id);
            StudentSponsor studentSponsor = studentRepository.FindStudentSponsorById(student.Id);
            Faculty faculty = studentRepository.GetFacultyByDepartmentId(student.DepartmentId);
            if (student == null)
            {
                ViewBag.ErrorMessage = $"The Student with Id = { Id } could not be found";
                return View("NotFound");
            }
            UpdateStudentDataViewModel model = new UpdateStudentDataViewModel
            {
                // Student Personal Information
                Id = student.Id,
                Firstname = student.Firstname,
                Middlename = student.Middlename,
                Lastname = student.Lastname,
                Gender = student.Gender,
                DateOfBirth = Convert.ToDateTime(student.DateOfBirth),
                PhoneNumber = student.PhoneNumber,
                AlternateEmailAddress = student.AlternateEmailAddress,
                EmailAddress = student.EmailAddress,
                Religion = student.Religion,
                MaritalStatus = student.MaritalStatus,
                ResidentialAddress = student.ResidentialAddress,
                ContactAddress = student.ContactAddress,
                AlternatePhoneNumber = student.AlternatePhoneNumber,
                ExistingPhotoPath = student.ProfilePhotoPath,
                DepartmentId = student.DepartmentId,
                FacultyId = faculty.Id,

                // Student Accademic Information
                NameOfInstitution = accademicInformation.NameOfInstitution,
                YearEnrolled = Convert.ToDateTime(accademicInformation.YearEnrolled),
                YearOfGraduation = Convert.ToDateTime(accademicInformation.YearOfGraduation),
                PreviousLevel = accademicInformation.PreviousLevel,

                // Student Next of kin information
                NextOfKinFirstname = nextOfKinInformation.NextOfKinFirstname,
                NextOfKinLastname = nextOfKinInformation.NextOfKinLastname,
                RelationToNextOfKin = nextOfKinInformation.RelationToNextOfKin,
                PhoneOfNextOfKin = nextOfKinInformation.PhoneOfNextOfKin,
                EmailOfNextOfKin = nextOfKinInformation.EmailOfNextOfKin,

                // Student Sponsor information
                SponsorFirstname = studentSponsor.SponsorFirstname,
                SponsorMiddlename = studentSponsor.SponsorMiddlename,
                SponsorLastname = studentSponsor.SponsorLastname,
                SponsorEmailAddress = studentSponsor.SponsorEmailAddress,
                SponsorPhoneNumber = studentSponsor.SponsorPhoneNumber,
                SponsorContactAddress = studentSponsor.SponsorContactAddress,
                SponsorProffession = studentSponsor.SponsorProffession,
                SponsorWorkAddress = studentSponsor.SponsorWorkAddress,
            };
            ListAllDepartments(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudentData(UpdateStudentDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = studentRepository.FindStudentById(model.Id);
                StudentAccademicInformation accademicInformation = studentRepository.FindStudentAccademicInformationById(student.Id);
                StudentNextOfKinInformation nextOfKinInformation = studentRepository.FindStudentNextofKinById(student.Id);
                StudentSponsor studentSponsor = studentRepository.FindStudentSponsorById(student.Id);
                if (student == null)
                {
                    ViewBag.ErrorMessage = $"The Student with Id = { model.Id } could not be found";
                    return View("NotFound");
                }
                IdentityUser user = await userManager.FindByIdAsync(student.IdentityUserId);
                user.Email = model.EmailAddress;
                user.PhoneNumber = model.PhoneNumber;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    // Update Student Personal information
                    student.Firstname = model.Firstname;
                    student.Middlename = model.Middlename;
                    student.Lastname = model.Lastname;
                    student.Gender = model.Gender;
                    student.DateOfBirth = model.DateOfBirth.ToLongDateString();
                    student.PhoneNumber = model.PhoneNumber;
                    student.AlternatePhoneNumber = model.AlternatePhoneNumber;
                    student.EmailAddress = model.EmailAddress;
                    student.Religion = model.Religion;
                    student.MaritalStatus = model.MaritalStatus;
                    student.ResidentialAddress = model.ResidentialAddress;
                    student.ContactAddress = model.ContactAddress;
                    student.AlternateEmailAddress = model.AlternateEmailAddress;
                    student.DepartmentId = model.DepartmentId;
                    student.CourseYearId = SetStudentCurrentYear(model.PreviousLevel.Value.ToString());
                    if (model.Image != null)
                    {
                        if (model.ExistingPhotoPath != null)
                        {
                            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", model.ExistingPhotoPath);
                            System.IO.File.Delete(filePath);
                        }
                        student.ProfilePhotoPath = processFileUpload.UploadImage(model.Image, "uploads");
                    }
                    studentRepository.UpdateStudent(student);
                    studentRepository.Save();

                    // Update Student Accademic information
                    accademicInformation.NameOfInstitution = model.NameOfInstitution;
                    accademicInformation.YearEnrolled = model.YearEnrolled.ToLongDateString();
                    accademicInformation.YearOfGraduation = model.YearOfGraduation.ToLongDateString();
                    accademicInformation.PreviousLevel = model.PreviousLevel;
                    studentRepository.UpdateStudentAccademicInformation(accademicInformation);
                    studentRepository.Save();

                    // Update Student Next of kin information
                    nextOfKinInformation.NextOfKinFirstname = model.NextOfKinFirstname;
                    nextOfKinInformation.NextOfKinLastname = model.NextOfKinLastname;
                    nextOfKinInformation.EmailOfNextOfKin = model.EmailOfNextOfKin;
                    nextOfKinInformation.PhoneOfNextOfKin = model.PhoneOfNextOfKin;
                    nextOfKinInformation.RelationToNextOfKin = model.RelationToNextOfKin;
                    studentRepository.UpdateStudentNextofKinformation(nextOfKinInformation);
                    studentRepository.Save();

                    // Update student sponsor information
                    studentSponsor.SponsorFirstname = model.SponsorFirstname;
                    studentSponsor.SponsorMiddlename = model.SponsorMiddlename;
                    studentSponsor.SponsorLastname = model.SponsorLastname;
                    studentSponsor.SponsorEmailAddress = model.SponsorEmailAddress;
                    studentSponsor.SponsorPhoneNumber = model.SponsorPhoneNumber;
                    studentSponsor.SponsorContactAddress = model.SponsorContactAddress;
                    studentSponsor.SponsorProffession = model.SponsorProffession;
                    studentSponsor.SponsorWorkAddress = model.SponsorWorkAddress;
                    studentRepository.UpdateStudentSponsorformation(studentSponsor);
                    studentRepository.Save();

                    return RedirectToAction("allstudents"); 
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> StudentDetails(long Id)
        {
            Student student = studentRepository.FindStudentById(Id);
            IdentityUser user = await userManager.FindByIdAsync(student.IdentityUserId);
            student.IdentityUser = user;
            StudentAccademicInformation accademicInformation = studentRepository.FindStudentAccademicInformationById(student.Id);
            StudentNextOfKinInformation nextOfKinInformation = studentRepository.FindStudentNextofKinById(student.Id);
            StudentSponsor studentSponsor = studentRepository.FindStudentSponsorById(student.Id);
            if (student == null)
            {
                ViewBag.ErrorMessage = $"The Student with Id = { Id } could not be found";
                return View("NotFound");
            }
            StudentDetailsViewModel model = new StudentDetailsViewModel
            {
                Student = student,
                StudentAccademicInformation = accademicInformation,
                StudentSponsor = studentSponsor,
                StudentNextOfKinInformation = nextOfKinInformation
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(long Id)
        {
            Student student = studentRepository.FindStudentById(Id);
            if(student == null)
            {
                ViewBag.ErrorMessage = $"The Student with Id = { Id } could not be found";
            }
            IdentityUser user = await userManager.FindByIdAsync(student.IdentityUserId);
            IdentityResult result = await userManager.DeleteAsync(user);
            if(result.Succeeded)
            {
                 if(student.ProfilePhotoPath != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", student.ProfilePhotoPath);
                    System.IO.File.Delete(filePath);
                }
                studentRepository.DeleteStudent(student);
                studentRepository.Save();
                return Json(new {success = true });
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("allstudents");
            } 
        }

        private AddStudentViewModel ListAllFaculties(AddStudentViewModel model)
        {
            var faculties = facultyRepository.GetAll();
            foreach(var faculty in faculties )
            {
                model.Faculties.Add(new SelectListItem { Text = faculty.FacultyName, Value = faculty.Id.ToString() });
            }
            return model;
        }

        private AddStudentViewModel ListAllDepartments(AddStudentViewModel model)
        {
            ListAllFaculties(model);
            var departments = studentRepository.GetDepartmentsByFacultyId(model.FacultyId);
            foreach(var department in departments)
            {
                model.Departments.Add(new SelectListItem { Text = department.DepartmentName, Value = department.Id.ToString() });
            }
            return model;
        }

        public JsonResult AjaxGetDepartments(long facultyId)
        {
            List<Department> department = new List<Department>();
            department = studentRepository.GetDepartmentsByFacultyId(facultyId).ToList();
            department.Insert(0, new Department { Id = 0, DepartmentName = "----- Select a Department -----" });
            return Json(new SelectList(department, "Id", "DepartmentName"));
        }

        private void SetStudentCourses(long studentId, long departmentId, long courseYearId)
        {
            var courses =  studentRepository.GetAllCoursesByDepartmentId(departmentId);
            foreach(var course in courses)
            {
                if(course.CourseYearId == courseYearId)
                {
                    StudentCourse studentCourse = new StudentCourse
                    {
                        StudentId = studentId,
                        CourseId = course.Id
                    };
                    studentRepository.InsertStudentCourse(studentCourse);
                    studentRepository.Save();
                }
                
            }
        }

        private long SetStudentCurrentYear(string previousYear)
        {
            var courseYears = courseYearRepo.GetAll();
            long currentYear = 0;
            foreach(var course in courseYears)
            {
                if(previousYear == "None" || previousYear == "FirstYear" || previousYear == "SecondYear" 
                && course.YearTitle == "First Year")
                {
                    currentYear = course.Id;
                }
                else if(previousYear == "ThirdYear" && course.YearTitle == "Third Year")
                {
                    currentYear = (course.Id - 1);
                }
                else if(previousYear == "FourthYear" && course.YearTitle == "Fourth Year")
                {
                    currentYear = (course.Id - 1);
                }
                else if(previousYear == "FinalYear" && course.YearTitle == "Final Year")
                {
                    currentYear = (course.Id - 1);
                }
            }
            return currentYear;
        }

        private string SetMatriculationNumber(long facultyId, long departmentId)
        {
            Faculty faculty = facultyRepository.GetById(facultyId);
            Department department = departmentRepository.GetById(departmentId);
            string lastMatricNumber = studentRepository.GetLastInputtedMatriculationNumber();
            var listOfMatricNumbers = studentRepository.GetAllMatricNumbers();
            string schoolNameAbrv = "NHU";
            string currentYear = DateTime.Now.Year.ToString();
            string matricNumberFormat = schoolNameAbrv + "/" + currentYear.Substring(2) + "/" + faculty.FacultyCode + "/" + department.DepartmentCode + "/";
            string newValue = InitialMatricValue();
            if(String.IsNullOrEmpty(lastMatricNumber))
            {
                return MatricNumberWithInintialNumbericValue(matricNumberFormat); 
            }
            else
            {
                string yearFromMatric = lastMatricNumber.Substring(4);
                if(currentYear.Substring(2) == yearFromMatric.Substring(0, yearFromMatric.IndexOf("/")))
                {
                    foreach(var numbers in listOfMatricNumbers)
                    {
                        string removeSchAbrandYr = numbers.Substring(7);
                        string getFacultyCode = removeSchAbrandYr.Substring(0, removeSchAbrandYr.IndexOf("/"));
                        string rmvSchAbrandSlash = removeSchAbrandYr.Substring(removeSchAbrandYr.IndexOf("/") + 1);
                        string getDptCode = rmvSchAbrandSlash.Substring(0, rmvSchAbrandSlash.IndexOf("/"));
                        string getLastDigits = numbers.Substring(numbers.Length - 5);

                        if(Int32.Parse(getFacultyCode) == faculty.FacultyCode)
                        {
                            if(Int32.Parse(getDptCode) == department.DepartmentCode)
                            { 
                                int valueFromLastDigits = Int32.Parse(getLastDigits) + 1;
                                newValue = valueFromLastDigits.ToString().PadLeft(5, '0'); 
                            }   
                        } 
                    }
                    return matricNumberFormat += newValue;
                } 
                return MatricNumberWithInintialNumbericValue(matricNumberFormat);
            }
        }

        protected string MatricNumberWithInintialNumbericValue(string matricNumberFormat)
        {
            int initialValue = Int32.Parse(new String('0', 4) + "1");
            string newValueString = initialValue.ToString().PadLeft(5, '0');
            matricNumberFormat += newValueString;
            return matricNumberFormat;
        }

        protected string InitialMatricValue()
        {
            int initialValue = Int32.Parse(new String('0', 4));
            string newValueString = initialValue.ToString().PadLeft(5, '0');
            return newValueString; 
        }

    }
}