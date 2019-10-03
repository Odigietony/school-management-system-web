using System.Collections.Generic;
using System.Linq   ;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext context;

        public TeacherRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddTeacherToCourseAsync(TeacherCourse course)
        { 
            context.TeacherCourses.Add(course);
            if(await context.SaveChangesAsync() == 1){
                return true;
            }
            return false;
        }

        public void DeleteTeacher(Teacher teacher)
        {
            context.Remove(teacher);
            context.SaveChanges(); 
        }

        public async Task<TeacherCourse> FindRelatedTeacherCourses(long courseId, long teacherId)
        {
            TeacherCourse course = await context.TeacherCourses.FirstOrDefaultAsync(c => c.CourseId == courseId && c.TeacherId == teacherId);
            return course;
        }

        public IEnumerable<TeacherContactInformation> GetAllTeacherData()
        {
            var teacherData = context.TeacherContactInformations.Include(t => t.Teacher).ThenInclude(i => i.IdentityUser);
            return teacherData;
        }

        public IQueryable<Teacher> GetAllTeachers()
        {
            return context.Teachers;
        }

        public Teacher GetTeacherById(long Id)
        {
            return context.Teachers.Find(Id);
        }

        public TeacherContactInformation GetTeacherContactInfoById(long Id)
        {
            var contactInfo = context.TeacherContactInformations.FirstOrDefault(t => t.TeacherId == Id);
            return contactInfo;
        }

        public TeacherHighestDegree GetTeacherHighestDegreeById(long Id)
        {
            return context.TeacherHighestDegrees.FirstOrDefault(h => h.TeacherContactInfoId == Id);
        }

        public TeacherOtherDegree GetTeacherOtherDegreeById(long Id)
        {
            return context.TeacherOtherDegrees.FirstOrDefault(o => o.TeacherHighestDegreeId == Id);
        }

        public TeacherHighestDegree InsertAndSaveHighestDegree(TeacherHighestDegree highestDegree)
        {
            context.TeacherHighestDegrees.Add(highestDegree);
            context.SaveChanges();
            return highestDegree;
        }

        public TeacherOtherDegree InsertAndSaveOtherDegree(TeacherOtherDegree otherDegree)
        {
            context.TeacherOtherDegrees.Add(otherDegree);
            context.SaveChanges();
            return otherDegree;
        }

        public Teacher InsertAndSaveTeacherData(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return teacher;
        }

        public TeacherContactInformation InsertContactData(TeacherContactInformation data)
        {
            context.TeacherContactInformations.Add(data);
            context.SaveChanges();
            return data;
        }

        public async Task<bool> RemoveTeacherFromCourse(TeacherCourse course)
        {
            TeacherCourse teacherCourse = context.TeacherCourses
                        .FirstOrDefault(c => c.CourseId == course.CourseId && c.TeacherId == course.TeacherId);
            context.Remove(teacherCourse);
            if(await context.SaveChangesAsync() == 1)
            {
                return true;
            }
            return false;


        }

        public void SaveTeacherData(Teacher teacher, TeacherContactInformation contactInformation,
        TeacherHighestDegree highestDegree, TeacherOtherDegree otherDegree)
        {
            context.Teachers.Add(teacher);
            context.TeacherContactInformations.Add(contactInformation);
            context.TeacherHighestDegrees.Add(highestDegree);
            context.TeacherOtherDegrees.Add(otherDegree);
            context.SaveChanges();
        }

        public async Task<bool> TeacherTeachesCourse(Teacher teacher, string courseName)
        { 
           var result = await context.TeacherCourses
                        .FirstOrDefaultAsync(t => t.Course.CourseName == courseName && t.TeacherId == teacher.Id);
           if(result != null)
           {
               return true;
           }
           return false;
        }

        public void UpdateTeacherContactData(TeacherContactInformation contactInformation)
        {
            context.TeacherContactInformations.Attach(contactInformation);
            context.Entry(contactInformation).State = EntityState.Modified; 
            context.SaveChanges();
        }

        public Teacher UpdateTeacherData(Teacher teacher)
        {
            context.Teachers.Attach(teacher);
            context.Entry(teacher).State = EntityState.Modified;
            context.SaveChanges();
            return teacher;
        }

        public void UpdateTeacherHighestDegreeData(TeacherHighestDegree highestDegree)
        {
            context.TeacherHighestDegrees.Attach(highestDegree);
            context.Entry(highestDegree).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void UpdateTeacherOtherDegreeData(TeacherOtherDegree otherDegree)
        {
            context.TeacherOtherDegrees.Attach(otherDegree);
            context.Entry(otherDegree).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}