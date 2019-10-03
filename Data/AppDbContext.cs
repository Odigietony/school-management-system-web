using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedUser();
            modelBuilder.SeedAdmin();
            modelBuilder.SeedCountry();
            modelBuilder.SeedStates();
            modelBuilder.SeedProgramYear();
            //Add the hasKey to the bridge table to prevent the (no primary key error)
            modelBuilder.Entity<TeacherCourse>()
                        .HasKey(x => new { x.CourseId, x.TeacherId });

            modelBuilder.Entity<StudentCourse>()
                        .HasKey(s => new { s.CourseId, s.StudentId });
        } 
        public DbSet<Admin> Admins {get; set;}
        public DbSet<Course> Courses {get; set;}
        public DbSet<CourseYear> CourseYears { get; set;}
        public DbSet<Department> Departments { get; set;}
        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Student> Students { get; set; }
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