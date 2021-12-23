﻿using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity for edit purposes
    /// </summary>
    public class GetOpportunityForEditOutput
    {
        public CreateOrEditOpportunityDto Opportunity { get; set; }

        public string OpportunityStageDescription { get; set; }

        public string LeadSourceDescription { get; set; }

        public string OpportunityTypeDescription { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public string ContactName { get; set; }
        
    }
}