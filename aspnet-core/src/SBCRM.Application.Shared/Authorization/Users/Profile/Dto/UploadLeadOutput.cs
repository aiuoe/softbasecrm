using Abp.Web.Models;

namespace SBCRM.Authorization.Users.Profile.Dto
{
    public class UploadLeadOutput : ErrorInfo
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public UploadLeadOutput()
        {
            
        }
    }
}