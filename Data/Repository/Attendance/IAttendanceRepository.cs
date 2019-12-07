using System.Linq;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public interface IAttendanceRepository
    {
        long NumberOfStudentsPresentToday();
        long NumberOfStudentsAbsentToday();
        void InsertRecord(Attendance attendance);
        void UpdateRecord(Attendance attendance);
        void DeleteRecord(Attendance attendance);
        void Save();
        IQueryable<Attendance> GetAllAttendance();
        IQueryable<Attendance> GetAllAttendanceByStudent(long Id);
        IQueryable<Attendance> GetAllAbsentStudentRecord();
        IQueryable<Attendance> GetAllPresentStudentRecord();
        IQueryable<Attendance> GetTodaysAbsentStudentRecord();
        IQueryable<Attendance> GetTodaysPresentStudentRecord();
        

    }
}