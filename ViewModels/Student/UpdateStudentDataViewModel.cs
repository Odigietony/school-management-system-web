namespace SchoolManagementSystem.ViewModels
{
    public class UpdateStudentDataViewModel : AddStudentViewModel
    {
        public long Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}