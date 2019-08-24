namespace SchoolManagementSystem.ViewModels
{
    public class EditAdminViewModel : CreateAdminViewModel
    {
        public long Id { get; set; }
        public string ExistingPhotoPath { get; set; }
        public string Username { get; set; }
    }
}