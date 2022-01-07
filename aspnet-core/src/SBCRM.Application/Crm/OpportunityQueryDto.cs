using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// DTO to manage the object query opportunity information
    /// </summary>
    public class OpportunityQueryDto : FullAuditedEntity
    {
        public string Name { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Probability { get; set; }

        public DateTime? CloseDate { get; set; }

        public string Description { get; set; }

        public int? BranchId { get; set; }

        public string? DepartmentId { get; set; }

        public int? OpportunityStageId { get; set; }

        public int? LeadSourceId { get; set; }

        public int? OpportunityTypeId { get; set; }

        public int? ContactId { get; set; }

        public string DepartmentTitle { get; set; }

        public string BranchName { get; set; }

        public string OpportunityStageDescription { get; set; }

        public string OpportunityStageColor { get; set; }

        public string LeadSourceDescription { get; set; }

        public string OpportunityTypeDescription { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public string ContactName { get; set; }

        public string FirstUserAssignedName { get; set; }

        public List<OpportunityUser> Users { get; set; }
    }
}