using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity
    /// </summary>
    public class OpportunityDto : EntityDto
    {
        public string Name { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Probability { get; set; }

        public DateTime? CloseDate { get; set; }

        public string Description { get; set; }

        public string Branch { get; set; }

        public string Department { get; set; }

        public int? OpportunityStageId { get; set; }

        public int? LeadSourceId { get; set; }

        public int? OpportunityTypeId { get; set; }

        public string CustomerNumber { get; set; }

        public int? ContactId { get; set; }

    }
}