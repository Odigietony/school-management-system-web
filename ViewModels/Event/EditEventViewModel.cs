namespace SchoolManagementSystem.ViewModels
{
    public class EditEventViewModel : AddEventViewModel
    {
        public long Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}