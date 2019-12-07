using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.Message;

namespace SchoolManagementSystem.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedCountry();
            modelBuilder.SeedStates();
            // modelBuilder.SeedProgramYear();
            //Add the hasKey to the bridge table to prevent the (no primary key error)
            modelBuilder.Entity<TeacherCourse>()
                        .HasKey(x => new { x.CourseId, x.TeacherId });

            modelBuilder.Entity<StudentCourse>()
                        .HasKey(s => new { s.CourseId, s.StudentId });
        } 
        public DbSet<Admin> Admins {get; set;}
        public DbSet<AdminTask> AdminTasks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses {get; set;}
        public DbSet<CourseYear> CourseYears { get; set;}
        public DbSet<Department> Departments { get; set;}
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherTask> TeacherTasks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCategory> LocationCategories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAttachment> MessageAttachments { get; set; }
        public DbSet<ReceivedMessage> ReceivedMessages { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentTask> StudentTasks { get; set; }
        public DbSet<StudentAccademicInformation> StudentAccademicInformations { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set;}
        public DbSet<StudentNextOfKinInformation> StudentNextOfKinInformations { get; set; }
        public DbSet<StudentSponsor> StudentSponsors { get; set; }
        public DbSet<TeacherCertificate> TeacherCertificates { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<TeacherContactInformation> TeacherContactInformations { get; set; }
        public DbSet<TeacherHighestDegree> TeacherHighestDegrees { get; set; }
        public DbSet<TeacherOtherDegree> TeacherOtherDegrees { get; set; }
        public DbSet<TeachersProffesionalInformation> TeachersProffesionalInformations { get; set; }
    }
}