namespace SchoolManagementSystem.Models
{
    public class TeacherOtherDegree
    {
        public long Id { get; set; }
        public string NameOfInstitution { get; set; }
        public string YearOfEnrollement { get; set; }
        public string YearOfGraduation { get; set; }
        public string DegreeAttained { get; set; }
        public double CGPA { get; set; }

        //Foreign Key
        public long TeacherHighestDegreeId { get; set; }
        public TeacherHighestDegree TeacherHighestDegree { get; set; }
    }
}