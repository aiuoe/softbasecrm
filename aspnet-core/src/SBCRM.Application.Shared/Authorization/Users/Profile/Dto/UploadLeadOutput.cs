using Abp.Web.Models;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;

namespace SBCRM.Authorization.Users.Profile.Dto
{
    /// <summary>
    /// This class is used as return data when importing Leads from an excel file
    /// </summary>
    public class UploadLeadOutput : ErrorInfo
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public List<CreateOrEditLeadDto> RepeatedLeads { get; set; }

        public UploadLeadOutput()
        {
            
        }
    }
}