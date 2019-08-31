namespace SchoolManagementSystem.Models
{
    public class TeacherHighestDegree
    {
        public long Id { get; set; }
        public string NameOfInstitution { get; set; }
        public string YearEnrolled { get; set; }
        public string YearOfGraduation { get; set; }
        public string DegreeAttained { get; set; }
        public double CGPA { get; set; }

        //Foreign Key
        public long TeacherId { get; set; }
    }
}