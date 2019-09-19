namespace SchoolManagementSystem.Models
{
    public class StudentAccademicInformation
    {
        public long Id { get; set; }
        public string NameOfInstitution { get; set; }
        public string YearEnrolled { get; set; }
        public string YearOfGraduation { get; set; }

        //Foreign Key
        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}