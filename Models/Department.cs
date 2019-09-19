namespace SchoolManagementSystem.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentCode { get; set; }
        public long FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}