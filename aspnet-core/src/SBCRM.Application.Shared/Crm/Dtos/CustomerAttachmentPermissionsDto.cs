using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm.Dtos
{

    /// <summary>
    /// Model to list the customer for widget permissions
    /// </summary>
    public class CustomerAttachmentPermissionsDto
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public List<AccountUserDto> Users { get; set; }
        public bool CanViewAttachments { get; set; }
        public bool CanAddAttachments { get; set; }
        public bool CanEditAttachments { get; set; }
        public bool CanDownloadAttachments { get; set; }
        public bool CanRemoveAttachments { get; set; }
    }
}