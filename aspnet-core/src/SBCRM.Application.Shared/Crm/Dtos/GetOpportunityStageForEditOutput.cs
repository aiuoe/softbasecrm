using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity stage for edit purposes
    /// </summary>
    public class GetOpportunityStageForEditOutput
    {
        public CreateOrEditOpportunityStageDto OpportunityStage { get; set; }

    }
}