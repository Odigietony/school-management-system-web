using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.ViewModels
{
    public class EditTeacherViewModel : AddTeacherViewModel
    {
        public long Id { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}