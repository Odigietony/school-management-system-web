using System;
using System.Linq;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext context;
        public AttendanceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteRecord(Attendance attendance)
        {
            context.Attendances.Remove(attendance);
        }

        public IQueryable<Attendance> GetAllAbsentStudentRecord()
        {
            return context.Attendances.Where(a => a.IsPresent == Enums.AttendanceStatus.Absent);
        }

        public IQueryable<Attendance> GetAllAttendance()
        {
            return context.Attendances;
        }

        public IQueryable<Attendance> GetAllAttendanceByStudent(long Id)
        {
            return context.Attendances.Where(a => a.StudentId == Id);
        }

        public IQueryable<Attendance> GetAllPresentStudentRecord()
        {
             return context.Attendances.Where(a => a.IsPresent == Enums.AttendanceStatus.Present);
        }

        public IQueryable<Attendance> GetTodaysAbsentStudentRecord()
        {
            return context.Attendances
            .Where(a => a.IsPresent == Enums.AttendanceStatus.Absent && a.Date == DateTime.Now.Date);
        }

        public IQueryable<Attendance> GetTodaysPresentStudentRecord()
        {
            return context.Attendances
            .Where(a => a.IsPresent == Enums.AttendanceStatus.Present && a.Date == DateTime.Now.Date);
        }

        public void InsertRecord(Attendance attendance)
        {
            context.Attendances.Add(attendance);
        }

        public long NumberOfStudentsAbsentToday()
        {
           return context.Attendances
            .Where(a => a.IsPresent == Enums.AttendanceStatus.Absent && a.Date == DateTime.Now.Date)
            .Count();
        }

        public long NumberOfStudentsPresentToday()
        {
            return context.Attendances
            .Where(a => a.IsPresent == Enums.AttendanceStatus.Present && a.Date == DateTime.Now.Date)
            .Count();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateRecord(Attendance attendance)
        {
            context.Attendances.Attach(attendance);
            context.Entry(attendance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}