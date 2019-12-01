using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Helpers
{
    public class ProcessUploadFile : IProcessFileUpload
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public ProcessUploadFile(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;

        }
        public string UploadImage(IFormFile file, string location)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string folderPath = Path.Combine(hostingEnvironment.WebRootPath, location);
                uniqueFileName = Guid.NewGuid() + "_" + file.FileName;
                string filePath = Path.Combine(folderPath, uniqueFileName);
                using(var filestream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
    }
}