using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public interface IStudentRepository
    {
        IQueryable<Student> FindAllStudent();
        Student FindStudentById(long Id);
        Student FindStudentByUserId(string Id);
        StudentAccademicInformation FindStudentAccademicInformationById(long Id);
        StudentNextOfKinInformation FindStudentNextofKinById(long Id);
        StudentSponsor FindStudentSponsorById(long Id);
        Faculty GetFacultyByDepartmentId(long Id);
        string GetLastInputtedMatriculationNumber();
        IQueryable<string> GetAllMatricNumbers();
        void InsertStudent(Student student);
        void InsertStudentAccademicInformation(StudentAccademicInformation accademicInformation);
        void InsertStudentNextOfKin(StudentNextOfKinInformation nextOfKinInformation);
        void InsertStudentSponsor(StudentSponsor studentSponsor);
        void UpdateStudent(Student student);
        void UpdateStudentAccademicInformation(StudentAccademicInformation accademicInformation);
        void UpdateStudentNextofKinformation(StudentNextOfKinInformation nextOfKinInformation);
        void UpdateStudentSponsorformation(StudentSponsor studentSponsor);
        void DeleteStudent(Student student);
        void InsertStudentCourse(StudentCourse studentCourse);
        ICollection<Department> GetDepartmentsByFacultyId(long Id);
        ICollection<Course> GetAllCoursesByDepartmentId(long Id);
        void Save();
    }
}