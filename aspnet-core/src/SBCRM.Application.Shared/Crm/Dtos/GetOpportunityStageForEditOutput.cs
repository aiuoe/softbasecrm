using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{

    public class GetOpportunityStageForEditOutput
    {
        public CreateOrEditOpportunityStageDto OpportunityStage { get; set; }

    }
}