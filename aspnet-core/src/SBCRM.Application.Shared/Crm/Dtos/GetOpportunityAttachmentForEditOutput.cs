using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A lead attachment model for edting purposes.
    /// </summary>
    public class GetOpportunityAttachmentForEditOutput
    {
        public CreateOrEditOpportunityAttachmentDto OpportunityAttachment { get; set; }

        public string OpportunityName { get; set; }

    }
}