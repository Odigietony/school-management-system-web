namespace SchoolManagementSystem.Models
{
    public class TeacherCertificate
    {
        public long Id { get; set; }
        public string CertificateTitle { get; set; }
        public string CertificateImagePath { get; set; }

        public long TeacherId { get; set; }
    }
}