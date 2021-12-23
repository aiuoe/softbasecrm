using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity type for edit purposes
    /// </summary>
    public class GetOpportunityTypeForEditOutput
    {
        public CreateOrEditOpportunityTypeDto OpportunityType { get; set; }

    }
}