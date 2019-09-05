using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Helpers
{
    public interface IProcessFileUpload
    {
        string UploadImage(IFormFile file);
    }
}