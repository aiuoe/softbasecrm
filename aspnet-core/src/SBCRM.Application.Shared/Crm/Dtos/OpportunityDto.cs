using System;
using System.Collections.Generic;
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

        public short? BranchId { get; set; }
   
        public short? DepartmentId { get; set; }
 
        public int? OpportunityStageId { get; set; }

        public int? LeadSourceId { get; set; }

        public int? OpportunityTypeId { get; set; }

        public string CustomerNumber { get; set; }

        public int? ContactId { get; set; }

        public List<OpportunityUserViewDto> Users { get; set; }
    }
}