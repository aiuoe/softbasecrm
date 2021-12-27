using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Dto for Creating or Editing
    /// </summary>
    public class CreateOrEditActivityDto : EntityDto<long?>
    {

        [Required]
        [StringLength(ActivityConsts.MaxTaskNameLength, MinimumLength = ActivityConsts.MinTaskNameLength)]
        public string TaskName { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime StartsAt { get; set; }

        public int DurationMinutes { get; set; }

        public string Description { get; set; }

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