using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public interface ITeacherRepository
    {
        //Insert and save teacher personal data
        Teacher InsertAndSaveTeacherData(Teacher teacher);
        //Get Teacher data
        Teacher GetTeacherById(long Id);
        //Edit teacher data
        Teacher UpdateTeacherData(Teacher teacher);
        //Delete teacher data
        void DeleteTeacher(Teacher teacher);

        //Get all teachers
        IQueryable<Teacher> GetAllTeachers();

        //Insert and save teacher contact info
        TeacherContactInformation InsertContactData(TeacherContactInformation data);

        //Insert and Save teacher highest degree
        TeacherHighestDegree InsertAndSaveHighestDegree(TeacherHighestDegree highestDegree);

        // Insert and Save teacher other degree
        TeacherOtherDegree InsertAndSaveOtherDegree(TeacherOtherDegree otherDegree);

        //Insert and save all teacher related data
        void SaveTeacherData(Teacher teacher, TeacherContactInformation contactInformation, 
                            TeacherHighestDegree highestDegree, TeacherOtherDegree otherDegree);

        // Get all Teacher related data
        IEnumerable<TeacherContactInformation> GetAllTeacherData();

        // Get Teacher contact information
        TeacherContactInformation GetTeacherContactInfoById(long Id);

        // Get the highest degree of a teacher
        TeacherHighestDegree GetTeacherHighestDegreeById(long Id);

        // Get the other degree of a teacher
        TeacherOtherDegree GetTeacherOtherDegreeById(long Id);

        // Update Teacher contact information
        void UpdateTeacherContactData(TeacherContactInformation contactInformation);

        // Update Teacher Highest degree information
        void UpdateTeacherHighestDegreeData(TeacherHighestDegree highestDegree);

        // Update teacher other degree information
        void UpdateTeacherOtherDegreeData(TeacherOtherDegree otherDegree);
        Task<bool> TeacherTeachesCourse(Teacher teacher, string courseName);

        Task<bool> AddTeacherToCourseAsync(TeacherCourse course);

        Task<bool> RemoveTeacherFromCourse(TeacherCourse course);

        Task<TeacherCourse> FindRelatedTeacherCourses(long courseId, long teacherId);
    }
}