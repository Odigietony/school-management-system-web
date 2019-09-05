using System.Collections.Generic;
using System.Linq;
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
        Teacher DeleteTeacher(long Id);

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
    }
}