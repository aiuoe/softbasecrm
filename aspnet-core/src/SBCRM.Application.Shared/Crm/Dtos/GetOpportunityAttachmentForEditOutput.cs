using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetOpportunityAttachmentForEditOutput
    {
        public CreateOrEditOpportunityAttachmentDto OpportunityAttachment { get; set; }

        public string OpportunityName { get; set; }

    }
}