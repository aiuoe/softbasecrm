using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Lead attachment model for editing purposes.
    /// </summary>
    public class GetLeadAttachmentForEditOutput
    {
        public CreateOrEditLeadAttachmentDto LeadAttachment { get; set; }

        public string LeadCompanyName { get; set; }

    }
}