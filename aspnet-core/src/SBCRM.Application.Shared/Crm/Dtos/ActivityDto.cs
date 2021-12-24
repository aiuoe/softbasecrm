using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the Activity entity
    /// </summary>
    public class ActivityDto : EntityDto<long>
    {
        public DateTime DueDate { get; set; }
        
        public DateTime StartsAt { get; set; }

        public int? OpportunityId { get; set; }

        public int? LeadId { get; set; }

        public long UserId { get; set; }

        public int ActivitySourceTypeId { get; set; }

        public int ActivityTaskTypeId { get; set; }

        public int ActivityStatusId { get; set; }

        public int ActivityPriorityId { get; set; }

        public string CustomerNumber { get; set; }
    }
}