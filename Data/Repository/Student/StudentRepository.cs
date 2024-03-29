using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;
        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
        }

        public IQueryable<Student> FindAllStudent()
        {
            var students = context.Students;
            return students;
        }

        public StudentAccademicInformation FindStudentAccademicInformationById(long Id)
        {
            return context.StudentAccademicInformations.FirstOrDefault(s => s.StudentId == Id);
        }

        public Student FindStudentById(long Id)
        {
            return context.Students.FirstOrDefault(s => s.Id == Id);
        }

        public Student FindStudentByUserId(string Id)
        {
            return context.Students.FirstOrDefault(s => s.IdentityUserId == Id);
        }

        public StudentNextOfKinInformation FindStudentNextofKinById(long Id)
        {
            return context.StudentNextOfKinInformations.FirstOrDefault(s => s.StudentId == Id);
        }

        public StudentSponsor FindStudentSponsorById(long Id)
        {
            return context.StudentSponsors.FirstOrDefault(s => s.StudentId == Id);
        }

        public ICollection<Course> GetAllCoursesByDepartmentId(long Id)
        {
            return context.Courses.Where(c => c.DepartmentId == Id).ToList();
        }

        public IQueryable<string> GetAllMatricNumbers()
        {
            return context.Students.Select(s => s.MatriculationNumber);
        }

        public ICollection<Department> GetDepartmentsByFacultyId(long Id)
        {
            return context.Departments.Where(d => d.FacultyId == Id).ToList();
        }

        public Faculty GetFacultyByDepartmentId(long Id)
        {
            var department = context.Departments.FirstOrDefault(d => d.Id == Id);
            return context.Faculties.FirstOrDefault(f => f.Id == department.FacultyId);
        }

        public string GetLastInputtedMatriculationNumber()
        {
            return context.Students.Select(s => s.MatriculationNumber).LastOrDefault();
        }

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }

        public void InsertStudentAccademicInformation(StudentAccademicInformation accademicInformation)
        {
            context.StudentAccademicInformations.Add(accademicInformation);
        }

        public void InsertStudentCourse(StudentCourse studentCourse)
        {
            context.StudentCourses.Add(studentCourse);
        }

        public void InsertStudentNextOfKin(StudentNextOfKinInformation nextOfKinInformation)
        {
            context.StudentNextOfKinInformations.Add(nextOfKinInformation);
        }

        public void InsertStudentSponsor(StudentSponsor studentSponsor)
        {
            context.StudentSponsors.Add(studentSponsor);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            context.Students.Attach(student);
            context.Entry(student).State = EntityState.Modified;
        }

        public void UpdateStudentAccademicInformation(StudentAccademicInformation accademicInformation)
        {
            context.StudentAccademicInformations.Attach(accademicInformation);
            context.Entry(accademicInformation).State = EntityState.Modified;
        }

        public void UpdateStudentNextofKinformation(StudentNextOfKinInformation nextOfKinInformation)
        {
            context.StudentNextOfKinInformations.Attach(nextOfKinInformation);
            context.Entry(nextOfKinInformation).State = EntityState.Modified;
        }

        public void UpdateStudentSponsorformation(StudentSponsor studentSponsor)
        {
            context.StudentSponsors.Attach(studentSponsor);
            context.Entry(studentSponsor).State = EntityState.Modified;
        }
    }
}