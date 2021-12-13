using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetOpportunityForEditOutput
    {
        public CreateOrEditOpportunityDto Opportunity { get; set; }

        public string OpportunityStageDescription { get; set; }

        public string LeadSourceDescription { get; set; }

        public string OpportunityTypeDescription { get; set; }

    }
}