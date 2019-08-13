using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.ViewModels
{
    public class AllRolesViewModel : EditRoleViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}